using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class CauhoiMetadata
    {
        [Display(Name = "Mã câu hỏi")]
        public int id { get; set; }
        [Display(Name ="Mã đề thi")]
        public Nullable<int> MaDeThi { get; set; }
        [Display(Name ="Đáp án")]
        public string DapAn { get; set; }
        [Display(Name = "Câu hỏi")]
        public string Cau_hoi { get; set; }
        [Display(Name = "Đáp án A")]
        public string Dap_an_1 { get; set; }
        [Display(Name = "Đáp án B")]
        public string Dap_an_2 { get; set; }
        [Display(Name = "Đáp án C")]
        public string Dap_an_3 { get; set; }
        [Display(Name = "Đáp án D")]
        public string Dap_an_4 { get; set; }
        [Display(Name = "Ghi chú")]
        public string Ghi_chu { get; set; }
        [Display(Name = "Độ khó")]
        public Nullable<int> Muc_do_kho { get; set; }
    }
}