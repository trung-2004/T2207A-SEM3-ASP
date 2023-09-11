using System;
using System.ComponentModel.DataAnnotations;

namespace T2207A_MVC.Models
{
    public class BrandViewModel
    {
        [Required(ErrorMessage = "Vui long nhap ten danh muc")]
        [MinLength(6, ErrorMessage = "Vui long nhap toi thieu 6 ki tu")]
        [Display(Name = "Name")]// hien thi ra ngoai view
        public string name { get; set; }
    }
}
