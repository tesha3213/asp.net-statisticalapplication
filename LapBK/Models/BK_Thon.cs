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
    using System.ComponentModel.DataAnnotations;

    public partial class BK_Thon
    {
        [Key]
        public int Id { get; set; }
        public string MaXa { get; set; }
        public string MaThon { get; set; }
        public string TenThon { get; set; }
    }
}
