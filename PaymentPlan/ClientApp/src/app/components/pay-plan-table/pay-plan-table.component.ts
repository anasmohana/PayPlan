import { Component, OnInit, Input } from '@angular/core';
import { MatTableDataSource } from '@angular/material'

@Component({
  selector: 'app-pay-plan-table',
  templateUrl: './pay-plan-table.component.html',
  styleUrls: ['./pay-plan-table.component.css']
})
export class PayPlanTableComponent implements OnInit {
  private _dataSource: any = [];

  periods : any;

  @Input()
  set dataSource(dataSource: any) {
    this.periods = new MatTableDataSource(dataSource);
   }
  get dataSource(): any { return this._dataSource; }

  displayedColumns = ["period", "dueDate", "payment", "installment", "monthlyInterest", "balance"];

  constructor() { }

  ngOnInit() {
  }
  

}
