using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2207A_MVC.Models.Product
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Vui long nhap ten danh muc")]
        [MinLength(6, ErrorMessage = "Vui long nhap toi thieu 6 ki tu")]
        [Display(Name = "Name")]// hien thi ra ngoai view
        public string name { get; set; }

        [Required(ErrorMessage = "Vui long nhap ten danh muc")]
        [Display(Name = "Price")]
        public double price { get; set; }

        [Required(ErrorMessage = "Vui long chon danh muc")]
        [Display(Name = "Image")]
        public string image { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "Vui long chon danh muc")]
        [Display(Name = "Category")]
        public int category_id { get; set; }

        [Required(ErrorMessage = "Vui long chon thuong hieu")]
        [Display(Name = "Brand")]
        public int brand_id { get; set; }
    }
}
