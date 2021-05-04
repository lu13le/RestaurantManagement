using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class Subcategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Subcategory Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
