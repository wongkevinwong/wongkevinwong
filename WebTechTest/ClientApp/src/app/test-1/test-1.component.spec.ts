import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Test1Component } from './test-1.component';

describe('CounterComponent', () => {
  let component: Test1Component;
  let fixture: ComponentFixture<Test1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [Test1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Test1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });


});
