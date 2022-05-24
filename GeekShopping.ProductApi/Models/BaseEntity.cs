using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductApi.Models
{
    public class BaseEntity
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }


    }
}
