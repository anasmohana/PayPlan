﻿using PaymentPlan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentPlan.Utility {

    public static class CalcUtility {

        public static double MonthlyInterest(double balance, double interest)
        {
            var ratePercent = interest / 100;
            return Math.Round((balance * ratePercent) * 30 / 360);
        }

        public static double PaymentAmount(LoanParams loanParams)
        {
            // rate of interest and number of payments for monthly payments
            var rateOfInterest = loanParams.Interest / 1200;
            var numberOfPayments = loanParams.NumberOfYears * 12;

            // loan amount
            return Math.Round((rateOfInterest * loanParams.LoanAmount) / (1 - Math.Pow(1 + rateOfInterest, numberOfPayments * -1)));
        }

        public static List<LoanPayPlan> CalcPayPlan(LoanParams loanParams)
        {
            var paymentPlans = new List<LoanPayPlan>();

            paymentPlans = loanParams.ISFixedPayment ? CalculateAnnuity(loanParams) : CalculateSerial(loanParams);

            return paymentPlans;
        }

        private static List<LoanPayPlan> CalculateAnnuity(LoanParams loanParams)
        {
            var paymentPlans = new List<LoanPayPlan>();
            var paymentAmount = PaymentAmount(loanParams);
            var balance = loanParams.LoanAmount;
            var payment = 0.0;
            var monthlyInterest = 0.0;
            var installment = 0.0;
            var periods = loanParams.NumberOfYears * 12;
            var dueDate = DateTime.Today;


            for (int i = 0; i <= periods; i++)
            {
                var loanPayPlan = new LoanPayPlan
                {
                    Period = i,
                    DueDate = dueDate.ToShortDateString(),
                    Payment = payment,
                    Installment = installment,
                    MonthlyInterest = monthlyInterest,
                    Balance = balance
                };

                paymentPlans.Add(loanPayPlan);
                dueDate = dueDate.AddMonths(1);
                monthlyInterest = MonthlyInterest(balance, loanParams.Interest);
                if (balance <= 0)
                {
                    break;
                }
                if (paymentAmount < 1)
                {
                    installment = balance;
                    balance = 0;
                    payment = installment + monthlyInterest;
                    var loanPayPlanTemp = new LoanPayPlan
                    {
                        Period = i,
                        DueDate = dueDate.ToShortDateString(),
                        Payment = payment,
                        Installment = installment,
                        MonthlyInterest = monthlyInterest,
                        Balance = balance
                    };
                    paymentPlans.Add(loanPayPlanTemp);
                    break;
                }
                if (i == (periods - 1))
                {
                    installment = balance;
                    balance = 0;
                    payment = installment + monthlyInterest;
                }
                else
                {
                    installment = paymentAmount - monthlyInterest;
                    balance = balance - installment;
                    payment = paymentAmount;
                }
            }
            return paymentPlans;
        }

        private static List<LoanPayPlan> CalculateSerial(LoanParams loanParams)
        {
            var paymentPlans = new List<LoanPayPlan>();
            var balance = loanParams.LoanAmount;
            var payment = 0.0;
            var monthlyInterest = 0.0;
            var installment = 0.0;
            var periods = loanParams.NumberOfYears * 12;
            var installmentAmount = Math.Round(loanParams.LoanAmount / periods);

            var dueDate = DateTime.Today;

            for (int i = 0; i <= periods; i++)
            {
                LoanPayPlan loanPayPlan = new LoanPayPlan
                {
                    Period = i,
                    DueDate = dueDate.ToShortDateString(),
                    Payment = payment,
                    Installment = installment,
                    MonthlyInterest = monthlyInterest,
                    Balance = balance
                };

                paymentPlans.Add(loanPayPlan);
                dueDate = dueDate.AddMonths(1);
                monthlyInterest = MonthlyInterest(balance, loanParams.Interest);
                if (balance <= 0)
                {
                    break;
                }
                if (installmentAmount < 1)
                {
                    installment = balance;
                    balance = 0;
                    payment = installment + monthlyInterest;
                    var loanPayPlanTemp = new LoanPayPlan
                    {
                        Period = i,
                        DueDate = dueDate.ToShortDateString(),
                        Payment = payment,
                        Installment = installment,
                        MonthlyInterest = monthlyInterest,
                        Balance = balance
                    };
                    paymentPlans.Add(loanPayPlanTemp);
                    break;
                }
                if (i == (periods - 1))
                {
                    installment = balance;
                    balance = 0;
                    payment = installment + monthlyInterest;
                }
                else
                {
                    installment = installmentAmount;
                    balance = balance - installment;
                    payment = installment + monthlyInterest;
                }
            }
            return paymentPlans;
        }

    }
}
