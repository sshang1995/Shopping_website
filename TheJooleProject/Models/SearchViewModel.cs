using System;
using System.Collections.Generic;


namespace TheJooleProject.DAL
{
    
    public class SearchViewModel
    {
        public class SubCategoryJoinCategory
        {
            public Category c1 { get; set; }
            public SubCategory c2 { get; set; }
        }
        public List<SubCategoryJoinCategory> t { get; set; }

        public List<Category> c { get; set; }

        
    }
}