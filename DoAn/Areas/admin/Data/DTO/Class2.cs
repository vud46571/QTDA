using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAn.Models;
using System.ComponentModel.DataAnnotations;

namespace DoAn.Areas.admin.Data.DTO
{
    public class Class2
    {
        [Required(ErrorMessage = "Not null")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Not null")]
        [DataType(DataType.Password)]
        public string Passwords { get; set; }
    }
}