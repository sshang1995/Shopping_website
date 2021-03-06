//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Joole.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class Consumer
    {
        [DisplayName("UserName")]
        [Required(ErrorMessage = "This Field is Required")]
        public string Consumer_Name { get; set; }
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "This Field is Required")]
        public string Email { get; set; }
        public byte[] Consumer_image { get; set; }
        //byte[]


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
