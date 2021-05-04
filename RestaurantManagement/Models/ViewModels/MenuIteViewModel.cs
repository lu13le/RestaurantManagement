using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models.ViewModels
{
    public class MenuIteViewModel
    {
        public MenuItem MenuItem { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Subcategory>Subcategories { get; set; }
    }
}
