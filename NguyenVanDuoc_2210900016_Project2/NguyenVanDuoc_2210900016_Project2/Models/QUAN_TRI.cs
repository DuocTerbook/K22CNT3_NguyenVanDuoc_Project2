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

    public partial class QUAN_TRI
    {
        [Display(Name ="Tài khoản")]
        public string Tai_khoan { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Mat_khau { get; set; }
        [Display(Name = "Trạng thái")]
        public byte Trang_thai { get; set; }
    }
}