using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheJooleProject.Models
{
    public class ProductSummaryViewModel
    {

        //public class ProductJoinSubCategory
        //{
        //    public SubCategory sc { get; set; }
        //    public Product prod { get; set; }

        //    //public Property prop { get; set; }

        //    //public TechSpecFilter t { get; set; }
        //}

       //public class PJSCTechSpec
       // {
       //     public ProductJoinSubCategory pjsc { get; set; }

       //     public TechSpecFilter t { get; set; }
       // }



        public class SubCategoryJoinTechSpec
        {

            public SubCategory sc { get; set; }
            public TechSpecFilter t { get; set; }
        }

        public class SubCategoryJoinTechSpecWithName
        {
            public SubCategoryJoinTechSpec sjt { get; set; }
            public Property p { get; set; }

            
        }

        public class ProductJoinSubCategoryAndName
        {
            public Product prod { get; set; }

            public IEnumerable<SubCategoryJoinTechSpecWithName> sjtn { get; set; }
        }

        
        public class Combo
        {
            public List<SubCategoryJoinTechSpecWithName> sjtn { get; set; }

            //public List<ProductJoinSubCategoryAndName> psjtn { get; set; }

            public List<SJPJoinPropertyAndValue> sjpv { get; set; }
        }

        public List<DAL.SearchViewModel.SubCategoryJoinCategory> t { get; set; }

        public List<Category> c { get; set; }

        //public List<SubCategoryJoinTechSpecWithName> sjtn;

        //public List<SubCategoryJoinTechSpec> sjt;


        public Combo combo;

        [Required]
        public string SubCategory { get; set; }

        [Required]
        public string subCategoryID { get; set; }




        public class SubCategoryJoinProduct
        {
            public Product prod { get; set; }
            public SubCategory sc { get; set; }

            
        }

        public class PropertyValJoinProperty
        {
            public PropertyValue propertyValue { get; set; }

            public Property prop { get; set; }
        }

        public class SJPJoinPropertyAndValue
        {
            public SubCategoryJoinProduct sjp { get; set; }

            //public Property prop { get; set; }

            //public PropertyValue propValue { get; set; }

            public IEnumerable<PropertyValJoinProperty> pvJp;


        }

        
    }
}