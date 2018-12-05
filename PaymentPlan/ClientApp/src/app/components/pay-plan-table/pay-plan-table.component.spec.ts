import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PayPlanTableComponent } from './pay-plan-table.component';

describe('PayPlanTableComponent', () => {
  let component: PayPlanTableComponent;
  let fixture: ComponentFixture<PayPlanTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PayPlanTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PayPlanTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
