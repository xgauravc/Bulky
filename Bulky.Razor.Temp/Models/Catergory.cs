using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bulky.Razor.Temp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(100)]
        public required string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "The value must be in between 1-100 ")]
        public int DisplayOrder { get; set; }
    }
}
