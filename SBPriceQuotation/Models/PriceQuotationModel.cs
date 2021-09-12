using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBPriceQuotation.Models
{
    public class PriceQuotationModel
    {
        //Made the Subtotal field required.
        [Required(ErrorMessage = "Please enter the Sales Price.")]
        //Specified the range of value for the Sub Total field.
        [Range (1,10000,ErrorMessage = "Sales Price must be a valid number greater than 0 and less than $10,000.00.")]
        //Making the data type nullable with (?) next to the decimal data type. 
        //Hence, if the user doesn't enter a value for this property, the MVC framework generates a error msg.
        public decimal? SubTotal { get; set; }

        //Making value is required for the property.
        //Hence, if the user doesn't enter a value for this property, the MVC framework generates a error msg.
        //Value of the property must be within the specified range of values.
        //Making the data type nullable with (?) next to the decimal data type. 
        //Hence, if the user doesn't enter a value for this property, the MVC framework generates a error msg.

        [Required(ErrorMessage = "Please enter the Discount Percent.")]
        [Range(0,100,ErrorMessage ="Discount Percentage must be within the range of 0 to 100.")]
        public decimal? DiscountPercent { get; set; }

        /// <summary>
        /// CalculateQuotationtotal() is a custom method to calculate the total price quotation.
        /// </summary>
        /// <returns></returns>
        public decimal? CalculateQuotationTotal()
        {
            //Made a data type nullable.
            decimal? discountAmount = (SubTotal * DiscountPercent) / 100;
            //Made a data type nullable.
            decimal? Total = 0;
            for (int i= 0; i < discountAmount; i++)
            {
                Total = (SubTotal - discountAmount);
            }
            return Total;
            
        }
        /// <summary>
        /// This is a custom method to calculate the discount amount.
        /// </summary>
        /// <returns></returns>
        public decimal? CalculateDisAmount()
        {
            decimal? discountAmount = 0;
            if (SubTotal > 0)
            {
                discountAmount = (SubTotal * DiscountPercent) / 100;
            }
            return discountAmount;
        }
        
    }
}
