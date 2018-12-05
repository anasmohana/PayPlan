using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentPlan.Models {

    public class LoanPayPlan {
        public int Period { get; set; }
        public string DueDate { get; set; }
        public double Payment { get; set; }
        public double Installment { get; set; }
        public double MonthlyInterest { get; set; }
        public double Balance { get; set; }
    }
}
