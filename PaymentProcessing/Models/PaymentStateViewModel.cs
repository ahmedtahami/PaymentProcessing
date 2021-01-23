using PaymentProcessing.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Models
{
    public class PaymentStateViewModel
    {
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public PaymentStateEnum State { get; set; }

    }
}
