using PaymentProcessing.Models;
using System.Threading.Tasks;

namespace PaymentProcessing
{
    public interface IPaymentHelper
    {
        Task<PaymentStateViewModel> Pay(PaymentViewModel model);
    }
}