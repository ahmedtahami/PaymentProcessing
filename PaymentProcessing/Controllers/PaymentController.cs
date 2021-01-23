using PaymentProcessing.Gateways;
using PaymentProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PaymentProcessing.Controllers
{
    public class PaymentController : ApiController
    {
        HttpRequestMessage requestMessage = new HttpRequestMessage();
        private IPaymentHelper _paymentHelper;
        public PaymentController(IPaymentHelper paymentHelper)
        {
            _paymentHelper = paymentHelper;
        }
        public string Get()
        {
            return "Welcome To API";
        }
        [HttpPost]
        public async Task<HttpResponseMessage> Pay([FromBody] PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var paymentState = await _paymentHelper.Pay(model);
                return requestMessage.CreateResponse(HttpStatusCode.OK, paymentState, GlobalConfiguration.Configuration);
            }
            else
            {
                return requestMessage.CreateResponse(HttpStatusCode.BadRequest, "Invalid Request", GlobalConfiguration.Configuration);
            }
        }

    }
}
