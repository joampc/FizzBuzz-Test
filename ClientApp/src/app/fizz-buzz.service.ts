import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FizzBuzzService {
  private apiUrl = 'https://localhost:7001/api/FizzBuzz';

  constructor(private http: HttpClient) { }

  getFizzBuzzSeries(randomNumber: number, limit: number): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiUrl}?randomNumber=${randomNumber}&limit=${limit}`);
  }
}