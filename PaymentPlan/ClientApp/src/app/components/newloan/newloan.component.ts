import { Component, OnInit } from '@angular/core';
import { NewloanService } from '../../services/newloan.service';

@Component({
  selector: 'app-newloan',
  templateUrl: './newloan.component.html',
  styleUrls: ['./newloan.component.css']
})
export class NewloanComponent implements OnInit {
  loanParams: any = { interest: 3.5, ISFixedPayment: true };
  dataSource: any = [];
  showTable: boolean = false;

  constructor(private loanService: NewloanService) { }

  ngOnInit() {
  }
  submit() {
    this.loanService.createPayPlan(this.loanParams).
      subscribe((payPlanPeriods: any) => {
        this.dataSource = payPlanPeriods;
        this.showTable = this.dataSource.length > 1 ? true : false;
      });

  }

  onAmountChange(event: any) {
    let minLoanAmount: number = 5000;
    let maxLoanAmount: number = 500000;

    let loanAmount = Math.round(event.target.value / 5000) * 5000;
    if (loanAmount == 0) {
      this.loanParams.loanAmount = minLoanAmount;
    }
    else if (loanAmount > maxLoanAmount) {
      this.loanParams.loanAmount = maxLoanAmount;
    }
    else {
      this.loanParams.loanAmount = loanAmount;
    }
  }

  onYearCahnge(event: any) {
    let minNumberOfYears: number = 1;
    let maxNumberOfYears: number = 10;

    let numberOfYears = Math.round(event.target.value);
    if (numberOfYears == 0) {
      this.loanParams.numberOfYears = minNumberOfYears;
    }
    else if (numberOfYears > maxNumberOfYears) {
      this.loanParams.numberOfYears = maxNumberOfYears;
    }
    else {
      this.loanParams.numberOfYears = numberOfYears;
    }
  }
  updateAmount(event: any) {
    this.loanParams.loanAmount = event.value;
  }
  updateYears(event: any) {
    this.loanParams.numberOfYears = event.value;
  }


}
