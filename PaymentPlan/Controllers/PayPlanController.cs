using Microsoft.AspNetCore.Mvc;
using PaymentPlan.Models;
using PaymentPlan.Utility;

namespace PaymentPlan.Controllers {
    [Route("api/payplan")]
    public class PayPlanController : Controller {

        public PayPlanController()
        {

        }

        [HttpPost]
        public IActionResult CreateOwner([FromBody] LoanParams loanParams)
        {
            var paymentplan = CalcUtility.CalcPayPlan(loanParams);
            return Ok(paymentplan);
        }
    }
}
