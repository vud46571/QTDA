using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DoAn.Models
{
    public class KetquaMetadata
    {
        [Display(Name = "Mã thành viên")]
        public int MaThanhVien { get; set; }
        [Display(Name = "Mã đề thi")]
        public int MaDeThi { get; set; }
        [Display(Name = "Điểm")]
        public string Diem { get; set; }
    }
}