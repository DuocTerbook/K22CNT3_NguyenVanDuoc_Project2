﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NguyenVanDuoc_2210900016_Project2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class chitietdonhang
    {
        [Display(Name ="Mã chi tiết đơn hàng")]
        public int MaCTDH { get; set; }
        [Display(Name ="Mã đơn hàng")]
        public Nullable<int> MaDon { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public Nullable<int> MaSP { get; set; }
        [Display(Name = "Số lượng")]
        public Nullable<int> SoLuong { get; set; }
    
        public virtual donhang donhang { get; set; }
        public virtual sanpham sanpham { get; set; }
    }
}
