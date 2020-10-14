using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TheJooleProject.DAL;
using TheJooleProject.Models;

namespace TheJooleProject.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Search()
        {
            
            using (var db = new JooleDatabaseEntities())
            {
                var searchService = new SearchService(db);
                var searchVM = new SearchViewModel();
                searchService.LoadSearchVM(ref searchVM);
                //var query = db.Categories.ToList();
                return View("Search", searchVM);
            }


                //return View("Search", query);
        }

        public ActionResult ProductSummary(ProductSummaryViewModel psvm)
        {
            

            if (!ModelState.IsValid) return RedirectToAction("Search", "Search");

            

            //string[] keys = Request.Form.AllKeys;
            //for (int i = 0; i < keys.Length; i++)
            //{
            //    Response.Write(keys[i] + ": " + Request.Form[keys[i]] + "<br>");
            //    var key = keys[i];
            //    var val = Request.Form[keys[i]];
            //}
            using (var db = new JooleDatabaseEntities())
            {
                var searchService = new ProductSummaryService(db);
                //var productSummaryVM = new ProductSummaryViewModel();
                searchService.LoadVM(ref psvm);
                return View("ProductSummary", psvm);
            }

        }

        public ActionResult Image()
        {

            string url = Request.Url.ToString();
            string id = url.Split('/').Last();
            int productID = Int32.Parse(id);
            using(var db=new JooleDatabaseEntities())
            {
                var imageData = db.Products.Where(x => x.ProductID == productID).Select(p => p.Product_image).Single();

                return File(imageData, "image/jpg");
            }
            
        }
    }
}