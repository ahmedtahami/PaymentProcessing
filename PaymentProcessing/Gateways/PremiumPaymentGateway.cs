using PaymentProcessing.Entities;
using PaymentProcessing.Models;
using System;

namespace PaymentProcessing.Gateways
{
    public class PremiumPaymentGateway : IPaymentGateway
    {
        public PaymentStateViewModel ProcessPayment()
        {
            Random random = new Random();
            int num = random.Next(1, 100);
            if (num % 2 == 0)
            {
                PaymentStateViewModel returnModel = new PaymentStateViewModel
                {
                    CreatedDate = DateTime.Now,
                    State = Entities.PaymentStateEnum.Processed
                };
                return returnModel;
            }
            else
            {
                PaymentStateViewModel returnModel = new PaymentStateViewModel
                {
                    CreatedDate = DateTime.Now,
                    State = Entities.PaymentStateEnum.Failed
                };
                return returnModel;
            }
        }
    }
}
