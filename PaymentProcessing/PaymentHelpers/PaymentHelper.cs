using PaymentProcessing.Entities;
using PaymentProcessing.Gateways;
using PaymentProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PaymentProcessing
{
    public class PaymentHelper : IPaymentHelper
    {
        private ICheapPaymentGateway _cheapPaymentGateway;
        private IExpensivePaymentGateway _expensivePaymentGateway;
        private ApplicationDbContext db = new ApplicationDbContext();
        public PaymentHelper(ICheapPaymentGateway cheapPaymentGateway, IExpensivePaymentGateway expensivePaymentGateway)
        {
            _expensivePaymentGateway = expensivePaymentGateway;
            _cheapPaymentGateway = cheapPaymentGateway;
        }
        public async Task<PaymentStateViewModel> Pay(PaymentViewModel model)
        {
            var payment = new Payment()
            {
                Amount = model.Amount,
                CardHolder = model.CardHolder,
                CreditCardNumber = model.CreditCardNumber,
                ExpirationDate = model.ExpirationDate,
                Id = new Guid(),
                SecurityCode = model.SecurityCode
            };
            var state = new PaymentState()
            {
                Payment = payment,
                PaymentId = payment.Id,
                CreatedDate = DateTime.Now,
                State = PaymentStateEnum.Pending
            };
            db.Payments.Add(payment);
            db.PaymentStates.Add(state);
            await db.SaveChangesAsync();
            if (model.Amount <= 20)
            {
                var paymentState = ProcessPayment(_cheapPaymentGateway, payment);
                return paymentState;
            }
            else if (model.Amount > 20 && model.Amount <= 500)
            {
                var paymentState = new PaymentStateViewModel();
                paymentState = ProcessPayment(_expensivePaymentGateway, payment);
                if (paymentState != null && paymentState.State == PaymentStateEnum.Processed)
                    return paymentState;
                else
                    paymentState = ProcessPayment(_cheapPaymentGateway, payment);
                    return paymentState;
            }
            throw new Exception("Payment Could Not Be Processed");
        }

        private PaymentStateViewModel ProcessPayment(IPaymentGateway gateway, Payment entity)
        {
            var request = gateway.ProcessPayment();
            var paymentState = new PaymentState() 
            {
                PaymentId = entity.Id,
                CreatedDate = request.CreatedDate,
                State = request.State,
                Id = new Guid()
            };
            db.PaymentStates.Add(paymentState);
            return request;
        }
    }
}