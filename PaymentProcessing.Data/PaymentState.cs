using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Data
{
    class PaymentState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public PaymentStateEnum State { get; set; }
        public Guid PaymentId { get; set; }
        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; }

    }
}
