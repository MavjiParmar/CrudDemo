import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Employee } from './employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private baseURL = "https://localhost:44359/api/Employee";

  constructor(private httpClient: HttpClient) { }
  
  getEmployeesList(): Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(`${this.baseURL}`);
  }

  createEmployee(employee: Employee): Observable<any>{
    return this.httpClient.post(`${this.baseURL}`, employee, { responseType: 'text' });
  }

  getEmployeeById(id: number): Observable<Employee>{
    return this.httpClient.get<Employee>(`${this.baseURL}/${id}`);
  }

  updateEmployee(id: number, employee: Employee): Observable<any>{
    return this.httpClient.put(`${this.baseURL}/${id}`, employee, { responseType: 'text' });
  }

  deleteEmployee(id: number): Observable<any>{
    return this.httpClient.delete(`${this.baseURL}/${id}`, { responseType: 'text' });
  }
}
