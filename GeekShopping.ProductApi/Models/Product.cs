using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductApi.Models
{
    [Table("[Products]")]
    public class Product : BaseEntity
    {
        [Column("[name]")]
        [Required]
        public string Name { get; set; }
        [Column("[price]")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }
        [Column("[description]")]
        [StringLength(500)]
        [Required]
        public string Description { get; set; }
        [Column("[category_name]")]
        [StringLength(50)]
        public string CategoryName { get; set; }
        [Column("[image_url]")]
        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
