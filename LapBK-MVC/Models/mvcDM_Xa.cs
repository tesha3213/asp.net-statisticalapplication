using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LapBK_MVC.Models
{
    public class mvcDM_Xa
    {
        public string MaTinh { get; set; }
        public string MaHuyen { get; set; }
        [Key]
        public string MaXa { get; set; }
        public string TenXa { get; set; }
        public int TTNT { get; set; }
        public string Xa { get; set; }
        public string Phuong { get; set; }
        public string ThiTran { get; set; }
    }
}