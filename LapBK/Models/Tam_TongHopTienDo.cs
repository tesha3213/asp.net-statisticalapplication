//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LapBK.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tam_TongHopTienDo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tam_TongHopTienDo()
        {
            this.Tam_TongHopTienDo1 = new HashSet<Tam_TongHopTienDo>();
        }
    
        public string MaTinh { get; set; }
        public string MaDonVi { get; set; }
        public string TenDonvi { get; set; }
        public string MaDonViCha { get; set; }
        public Nullable<int> Cap { get; set; }
        public string LoaiDonvi { get; set; }
        public Nullable<int> TSDiaBan { get; set; }
        public Nullable<int> TSDiaBanHT { get; set; }
        public Nullable<int> TSHo { get; set; }
        public Nullable<int> SoHoMau { get; set; }
        public Nullable<int> SoHoWeb { get; set; }
        public Nullable<int> TSNha { get; set; }
        public Nullable<int> TSNguoi { get; set; }
        public Nullable<int> TSNu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tam_TongHopTienDo> Tam_TongHopTienDo1 { get; set; }
        public virtual Tam_TongHopTienDo Tam_TongHopTienDo2 { get; set; }
    }
}
