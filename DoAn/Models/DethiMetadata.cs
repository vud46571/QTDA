using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DoAn.Models
{
    public class DethiMetadata
    {
        [Display(Name = "Mã đề")]
        public int id { get; set; }
        [Display(Name ="Ngày thi")]
        public Nullable<System.DateTime> NgayThi { get; set; }
        [Display(Name = "Thời gian thi")]
        public string ThoiGianThi { get; set; }
        [Display(Name = "Số lượng câu hỏi")]
        public Nullable<int> SoLuongCauHoi { get; set; }
    }
}