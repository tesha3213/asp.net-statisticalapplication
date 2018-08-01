using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LapBK_MVC.Models
{
    public class mvcBK_Ho
    {
        [Key]
        public string IdHo { get; set; }
        public string MaTinh { get; set; }
        public string MaHuyen { get; set; }
        public string MaXa { get; set; }
        public string MaThon { get; set; }
        public string MaDiaBan { get; set; }
        public Nullable<double> Latitude_V { get; set; }
        public Nullable<double> Longitude_K { get; set; }
        public string SttNha { get; set; }
        public string SttHo { get; set; }
        public int TTNT { get; set; }
        public string TenChuHo { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public int TongSoNguoi { get; set; }
        public int TongSoNu { get; set; }
        public Nullable<bool> IsWebForm { get; set; }
        public Nullable<bool> IsHoMau { get; set; }
        public string GhiChu { get; set; }
        public string FullAddress { get; set; }
        public string StreetNum { get; set; }
        public string StreetName { get; set; }
        public string Village { get; set; }
        public string WardsName { get; set; }
        public string DistrictName { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
    }
}