using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Models
{
    public class PaymentViewModel
    {
        [CreditCard]
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        public string SecurityCode { get; set; }
        [Required]
        [DateValidation]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }
    }

    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime temp = Convert.ToDateTime(value);
            return temp >= DateTime.Now;
        }
    }
}
