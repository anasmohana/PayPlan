import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class NewloanService {

  constructor(private http: HttpClient) { }

  createPayPlan(loanParams){
    return this.http.post('/api/payplan', loanParams);
  }

}
