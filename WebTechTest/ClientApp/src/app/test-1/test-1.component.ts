import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test-1-component',
  templateUrl: './test-1.component.html'
})

export class Test1Component
{
  public people: Person[];

  private http: HttpClient;
  private getPeopleUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.http = http;
    this.getPeopleUrl = baseUrl + 'test1';
    this.getPeople();
  }

  getPeople = () =>
  {
    this.http.get<Person[]>(this.getPeopleUrl).subscribe(result =>
    {
      debugger;
      this.people = result;
    }, error => console.error(error));
  }
}

interface Person
{
  name: string;
  surname: string;
  adGroups: string[];
}
