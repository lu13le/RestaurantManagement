﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }


        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public double OrderTotalOriginal { get; set; }


        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Order total")]
        public double OrderTotal { get; set; }


        [Required]
        [DisplayName("Pickup time")]
        public DateTime PickUpTime { get; set; }


        [Required]
        [NotMapped]
        public DateTime PickUpDate { get; set; }


        [Display(Name ="Coupon code")]
        public string CouponCode { get; set; }
        public double CouponCodeDiscount { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public string Comments { get; set; }


        [Display(Name ="Pickup name")]
        public string PickupName { get; set; }


        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string TranscationId { get; set; }

    }
}
