using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DoAn.Models
{
    public class CTKQMetadata
    {
        [Display(Name = "Mã thành viên")]
        public int MaThanhVien { get; set; }
        [Display(Name = "Mã câu hỏi")]
        public int MaCauHoi { get; set; }
        [Display(Name = "Kết quả")]
        public string KQ { get; set; }
        [Display(Name = "Câu hỏi")]
        public virtual CauHoi CauHoi { get; set; }
        [Display(Name = "Thành viên")]
        public virtual ThanhVien ThanhVien { get; set; }
    }
}