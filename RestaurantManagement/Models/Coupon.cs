using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Type of Coupon")]
        public string CouponType { get; set; }
        public enum ECouponType {Percent=0,Dollar=1}
        [Required]
        public double Discount { get; set; }
        [Required]
        [DisplayName("Minimal amount")]
        public int MinimalAmount { get; set; }
        public byte[] Picture { get; set; }
        [DisplayName("Coupon is Active")]
        public bool IsActive { get; set; }

    }
}
