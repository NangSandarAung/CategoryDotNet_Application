using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookListApplication.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Display Order for category must be greater than 0")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
