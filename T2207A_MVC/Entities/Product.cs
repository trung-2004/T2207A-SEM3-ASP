using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2207A_MVC.Entities
{
    [Table("products")]
    public class Product
    {
        [Key]
        public int id { get; set; }// abstract property

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [Required]
        public double price { get; set; }

        [Required]
        public string image { get; set; }

        [Column(TypeName = "text")] // khai bao kieu du lieu
        public string description { get; set; }

        public int category_id { get; set; }

        public int brand_id { get; set; }

        [ForeignKey("category_id")]
        public Category category { get; set; }

        [ForeignKey("brand_id")]
        public Brand brand { get; set; }
    }
}
