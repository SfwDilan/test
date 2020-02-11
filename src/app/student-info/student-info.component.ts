import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormArray, Validators, FormGroup } from '@angular/forms';
import { StudentService } from '../shared/student.service';
import {HttpClient} from '@angular/common/http'

@Component({
  selector: 'app-student-info',
  templateUrl: './student-info.component.html',
  styleUrls: ['./student-info.component.css']
})
export class StudentInfoComponent implements OnInit {
  studentInfoForms: FormArray=this.fb.array([]);
  notification=null;
  constructor(private http:HttpClient ,private fb:FormBuilder,
    private studentService:StudentService) { }

  ngOnInit(): void {
    this.studentService.getStudentList().subscribe(
      res=>{
        if(res==[])
        this.addStudentInfoForm();
        else{
          (res as []).forEach((studentInfo:any)=>{
            this.studentInfoForms.push(this.fb.group({
              stId:[studentInfo.stId],
              tckn:[studentInfo.tckn],
              firstName:[studentInfo.firstName],
              lastName:[studentInfo.lastName],
              birthday:[studentInfo.birthday],
              city:[studentInfo.city],
              gender:[studentInfo.gender]
            }));
          });
        }
      }
    );
  }

  recordSubmit(fg:FormGroup){
    return this.studentService.postStudent(fg.value).subscribe(
      (res:any)=>{
        fg.patchValue({stId:res.stId});
      }
    )
  }

  addStudentInfoForm(){
    this.studentInfoForms.push(this.fb.group({
      stId:[0],
      tckn:['',Validators.required],
      firstName:['',Validators.required],
      lastName:['',Validators.required],
      birthday:Date,
      city:['',Validators.required],
      gender:['',Validators.required]
    }));
  }
 

}
