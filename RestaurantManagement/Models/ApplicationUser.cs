using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [DisplayName("Street Address")]
        public string StreetAdress { get; set; }
        public string City { get; set; }
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
    }
}
