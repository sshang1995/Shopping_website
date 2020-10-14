using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web;
using Joole.Data;
namespace TheJooleProject.Models
{
    public class ProductSummaryService
    {
        JooleDatabaseEntities jdbContext;
        public ProductSummaryService(JooleDatabaseEntities jdbContext)
        {
            this.jdbContext = jdbContext;

        }
        

        public List<Category> allCategories { get { return jdbContext.Categories.ToList(); } }

        //public List<SubCategory> allSubCategories { get { return jdbContext.SubCategories.ToList(); } }



        private List<SearchViewModel.SubCategoryJoinCategory> allSubCategoriesByCategory
        {
            get
            {
                var scByCID = jdbContext.Categories.Join(
                    jdbContext.SubCategories, c => c.CategoryID, d => d.CategoryID, (c, d) => new SearchViewModel.SubCategoryJoinCategory { c1 = c, c2 = d }

                    ).ToList();
                return scByCID;
            }

        }

        public List<SubCategory> subCategoryByCategoryId(int category)
        {
            return jdbContext.SubCategories.Where(s => s.CategoryID == category).ToList();
        }

        

        private List<ProductSummaryViewModel.SubCategoryJoinTechSpecWithName> allTechSpecBySubCategory
        {
            get
            {
                var sjt = jdbContext.SubCategories.Join(
                    jdbContext.TechSpecFilters, s => s.SubCategoryID, t => t.SubCategoryID, (s, t) => new ProductSummaryViewModel.SubCategoryJoinTechSpec { sc = s, t = t });
                var sjtlist = sjt.ToList();
                var sjtn = sjt.Join(jdbContext.Properties, x => x.t.PropertyID, p => p.PropertyID, (x, p) => new ProductSummaryViewModel.SubCategoryJoinTechSpecWithName { sjt = x, p = p }).ToList();

                return sjtn;
            }
        }

        //private List<ProductSummaryViewModel.SubCategoryJoinTechSpecWithName> allTechSpecBySubCategoryID(int id)
        private ProductSummaryViewModel.Combo allTechSpecBySubCategoryID(int id)
        {

            var sjt = jdbContext.SubCategories.Join(
                    jdbContext.TechSpecFilters, s => s.SubCategoryID, t => t.SubCategoryID, (s, t) => new ProductSummaryViewModel.SubCategoryJoinTechSpec { sc = s, t = t }).Where(e => e.sc.SubCategoryID == id);
            var sjtlist = sjt.ToList();
            var sjtn = sjt.Join(jdbContext.Properties, x => x.t.PropertyID, p => p.PropertyID, (x, p) => new ProductSummaryViewModel.SubCategoryJoinTechSpecWithName { sjt = x, p = p });
            var sjtnList = sjtn.ToList();

            

            var sjp = jdbContext.SubCategories.Where(e => e.SubCategoryID == id).Join(jdbContext.Products, s => s.SubCategoryID, p => p.SubCategoryID, (s, p) => new ProductSummaryViewModel.SubCategoryJoinProduct { prod = p, sc = s });
            var sjpList = sjp.ToList();


            var propJoinVal = jdbContext.PropertyValues.Join(jdbContext.Properties, propVal => propVal.PropertyID, prop => prop.PropertyID, (propVal, prop) => new ProductSummaryViewModel.PropertyValJoinProperty { prop=prop, propertyValue=propVal});
            var propJoinValList = propJoinVal.ToList();


            var sjpJOINporpJoinVal = sjp.GroupJoin(propJoinVal, x => x.prod.ProductID, y => y.propertyValue.ProductID, (x, y) => new ProductSummaryViewModel.SJPJoinPropertyAndValue {sjp=x, pvJp=y }).ToList();




            var typefilter = jdbContext.TypeFilters.Where(tf => tf.SubCategoryID == id).Select(tf => new ProductSummaryViewModel.TF { typename=tf.Type_Name }).ToList().Distinct();

            var propValJointf = jdbContext.PropertyValues.Join(jdbContext.TypeFilters, pv => pv.PropertyID, tf => tf.PropertyID, (pv, tf) => new { propVal=pv, typeFilter=tf });

            return new ProductSummaryViewModel.Combo { sjtn = sjtnList, sjpv=sjpJOINporpJoinVal, tf=typefilter };


            //var val =  jdbContext.SubCategories.Join(jdbContext.TechSpecFilters, s => s.SubCategoryID, t => t.SubCategoryID, (s, t) => new ProductSummaryViewModel.SubCategoryJoinTechSpec { sc = s, t = t }).Where(e => e.sc.SubCategoryID == Int32.Parse(id)).ToList();
            //return val;
        } 

        public void LoadVM(ref ProductSummaryViewModel s)
        {
            s.t = allSubCategoriesByCategory;
            s.c = allCategories;
             int sid = Int32.Parse(s.subCategoryID);
            s.combo = allTechSpecBySubCategoryID(sid);
            
            
            
            //s.sjtn = s.sjtn.Where(c => c.sjt.sc.SubCategoryID == sid);
        }

    }
}