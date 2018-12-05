import { Component, OnInit } from '@angular/core';
import { NewloanService } from '../../services/newloan.service';

@Component({
  selector: 'app-newloan',
  templateUrl: './newloan.component.html',
  styleUrls: ['./newloan.component.css']
})
export class NewloanComponent implements OnInit {
  loanParams: any = { interest: 3.5 };
  dataSource: any = [];
  showTable: boolean = false;

  constructor(private loanService: NewloanService) { }

  ngOnInit() {
  }
  submit() {
    this.loanService.createPayPlan(this.loanParams).
      subscribe((payPlanPeriods:any) => {
        this.dataSource = payPlanPeriods;
        this.showTable = this.dataSource.length > 1 ? true : false;
      });
    
  }
  updateAmount(event: any) {
    this.loanParams.loanAmount = event.value;
  }
  updateYears(event: any) {
    this.loanParams.numberOfYears = event.value;
  }


}
