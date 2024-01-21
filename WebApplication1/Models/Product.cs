using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required]
        public List<string>? Categories { get; set; }
        [Required]
        [DisplayName("Image Source")]
        public string? ImgSrc { get; set; }
    }
}
