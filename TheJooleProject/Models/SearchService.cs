using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Joole.Data;
namespace TheJooleProject.DAL
{
    public class SearchService
    {
        JooleDatabaseEntities jdbContext;
        public SearchService(JooleDatabaseEntities jdbContext)
        {
            this.jdbContext = jdbContext;
        }
        public List<Category> allCategories { get { return jdbContext.Categories.ToList(); } }

        //public List<SubCategory> allSubCategories { get { return jdbContext.SubCategories.ToList(); } }

       
        
        private List<SearchViewModel.SubCategoryJoinCategory> allSubCategoriesByCategory{
            get
            {
                var scByCID =  jdbContext.Categories.Join(
                    jdbContext.SubCategories, c => c.CategoryID, d => d.CategoryID, (c, d) => new SearchViewModel.SubCategoryJoinCategory{ c1 = c, c2 = d }

                    ).ToList();
                return scByCID;
            }

        }

        public List<SubCategory> subCategoryByCategoryId(int category)
        {
            return jdbContext.SubCategories.Where(s => s.CategoryID == category).ToList();
        }

        public void LoadSearchVM(ref SearchViewModel s)
        {
            s.t = allSubCategoriesByCategory;
            s.c = allCategories;
        }




    }
}