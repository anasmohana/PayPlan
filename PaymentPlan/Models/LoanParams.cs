using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentPlan.Models {

    public class LoanParams {
        public double LoanAmount { get; set; }
        public double Interest { get; set; }
        public int NumberOfYears { get; set; }
    }
}
