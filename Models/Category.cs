using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCProductCategory.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
