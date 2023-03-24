using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DoAn.Areas.User.Model.DTO
{
    public class UserModel
    {
        [Required(ErrorMessage = "Not null")]
        public string Users { get; set; }
        [Required(ErrorMessage = "Not null")]
        [DataType(DataType.Password)]
        public string Passwords { get; set; }
    }
}