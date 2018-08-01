using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LapBK_MVC.Models
{
    public class mvcDM_Huyen
    {
        public string MaTinh { get; set; }
        [Key]
        public string MaHuyen { get; set; }
        public string TenHuyen { get; set; }
    }
}