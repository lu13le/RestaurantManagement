using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Utility
{
    public static class SD
    {
        public const string DefaultFoodImage = "logo.jpg";
        public const string ManagerUser = "Manager";
        public const string KitchenUser = "Kitchen";
        public const string FrontDeskUser = "Front Desk";
        public const string CustomerEndUser = "Customer";


        public const string ssShoppingCartCount = "SD.ssShoppingCartCount";
        public const string ssCouponCode = "ssCouponCode";





		//basic fuction converting html to rawHtml
		public static string ConvertToRawHtml(string source)
		{
			char[] array = new char[source.Length];
			int arrayIndex = 0;
			bool inside = false;

			for (int i = 0; i < source.Length; i++)
			{
				char let = source[i];
				if (let == '<')
				{
					inside = true;
					continue;
				}
				if (let == '>')
				{
					inside = false;
					continue;
				}
				if (!inside)
				{
					array[arrayIndex] = let;
					arrayIndex++;
				}
			}
			return new string(array, 0, arrayIndex);
		}

		public static double DiscountedPrice(Coupon couponFromDb,double OriginalOrderTotal)
        {
			if(couponFromDb==null)
            {
				return OriginalOrderTotal;
            }
			else
            {
				if(couponFromDb.MinimalAmount>OriginalOrderTotal)
                {
					return OriginalOrderTotal;
                }
				else
                {
					//everything is valid

					if (Convert.ToInt32(couponFromDb.CouponType) == (int)Coupon.ECouponType.Dollar)
                    {
						//$10 of $100
						return Math.Round(OriginalOrderTotal - couponFromDb.Discount, 2);
                    }
					else
                    {
						if(Convert.ToInt32(couponFromDb.CouponType)==(int)Coupon.ECouponType.Percent)
                        {
							//%10 of %100
							return Math.Round(OriginalOrderTotal - (OriginalOrderTotal * couponFromDb.Discount / 100), 2);
						}
					}
                }
            }
			return OriginalOrderTotal;
        }
	}
}
