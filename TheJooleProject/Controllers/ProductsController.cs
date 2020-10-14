using Joole.Data;
using Joole.Service;
using Microsoft.Ajax.Utilities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using TheJooleProject;
using TheJooleProject.Models;

namespace TheJooleProject.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService productService = new ProductService();
        //private ProductService productServiceNew = new ProductService();
        private IPropertyService propertyService = new PropertyService();
        // GET: Products
        public ActionResult Index()
        {
            List<ProductDetailsVM> model= new List<ProductDetailsVM>();


            productService.GetProducts().ToList().ForEach(p =>
            {
                ProductDetailsVM vm = feedProductVM(p);
                model.Add(vm);
            });
            
            return View(model);
        }
        public ActionResult ProductDetails(long? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product p = productService.GetProduct(id.Value);
            
            if (p == null)
            {
                return HttpNotFound();
            }
            ProductDetailsVM model = feedProductVM(p);
            return View("ProductDetails", model);
        }
        [HttpGet]
        public ActionResult ProductsCompare(long? id1, long? id2, long? id3)
        {
            long?[] ids = { id1, id2, id3};
            List<ProductDetailsVM> model = new List<ProductDetailsVM>();
            foreach (long? id in ids) {
                if (id != null && id.Value != -1)
                {
                    Product p = productService.GetProduct(id.Value);
                    ProductDetailsVM vm = feedProductVM(p);
                    model.Add(vm);
                }
            }
            ViewBag.Model = model;
            return View();
        }

        private ProductDetailsVM feedProductVM (Product p){
            ProductDetailsVM pd = new ProductDetailsVM
            {
                ProductID = p.ProductID,
                ManufactureName = p.Manufacturer.Manufacturer_Name,
                Series = p.Series,
                Model = p.Model,
                Product_image = p.Product_image,
                Model_Year = p.Model_Year,
                Spec_Property = new List<PropertyVM>(),

                Type_Property = new List<PropertyVM>()
            };
            p.PropertyValues.ToList().ForEach(pv => {
                var property = propertyService.GetProperty(pv.PropertyID);
                PropertyVM pt = new PropertyVM
                {
                    PropertyName = property.PropertyName,
                    PropertyValue = pv.Value.ToString(),
                };
                if (property.IsTechSpec == 1)
                {
                    pd.Spec_Property.Add(pt);
                }
                else
                {
                    pd.Type_Property.Add(pt);
                }
            });
            return pd;
            
        }
    }

    
}
