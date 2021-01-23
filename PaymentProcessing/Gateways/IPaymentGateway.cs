using PaymentProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Gateways
{
    public interface IPaymentGateway
    {
        PaymentStateViewModel ProcessPayment();
    }
}
