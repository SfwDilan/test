import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }

  
  postStudent(formData) {
    return this.http.post(environment.apiBaseURI + '/students', formData);
  }

  getStudentList() {
    return this.http.get(environment.apiBaseURI + '/students');
  }
}
