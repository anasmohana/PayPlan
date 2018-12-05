import { TestBed, inject } from '@angular/core/testing';

import { NewloanService } from './newloan.service';

describe('NewloanService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NewloanService]
    });
  });

  it('should be created', inject([NewloanService], (service: NewloanService) => {
    expect(service).toBeTruthy();
  }));
});
