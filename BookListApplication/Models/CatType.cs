using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListApplication.Models
{
    public class CatType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Type")]
        public string CatTypeName { get; set; }
    }
}
