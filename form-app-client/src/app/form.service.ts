import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FormService {
  private apiUrl = 'http://localhost:5251/api/form';

  constructor(private http: HttpClient) {}

  submit(data: { firstName: string; lastName: string }): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }
}