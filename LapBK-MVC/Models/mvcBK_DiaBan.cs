using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LapBK_MVC.Models
{
    public class mvcBK_DiaBan
    {
        [Key]
        public int Id { get; set; }
        public string MaXa { get; set; }
        public string MaThon { get; set; }
        public string MaDiaBan { get; set; }
        public string TenDiaBan { get; set; }
        public Nullable<int> TongSoHo { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> IsDiaBanMau { get; set; }
    }
}