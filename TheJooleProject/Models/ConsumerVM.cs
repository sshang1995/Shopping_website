using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TheJooleProject.Models
{
    public class ConsumerVM
    {
        [DisplayName("UserName")]
        [Required(ErrorMessage = "This Field is Required")]
        public string Consumer_Name { get; set; }
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "This Field is Required")]
        public string Email { get; set; }
        public byte[] Consumer_image { get; set; }
        //byte[]
        public int ConsumerID { get; set; }


        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string LoginErrorMessage { get; set; }


    }
}