using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Joole.Data;

namespace TheJooleProject.Models
{
    public class ProductDetailsVM
    {
        //property for Description 
        [Key]
        public int ProductID { get; set; }
        public string ManufactureName { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public byte[] Product_image { get; set; }
        //property for TYPE
        public Nullable<int> Model_Year { get; set; }
        public ICollection<PropertyVM> Type_Property { get; set; }

        //property for techspec
        public ICollection<PropertyVM> Spec_Property { get; set; }
        
    }
}