import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { HomeComponent } from '../Component/home/home.component';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule,CommonModule,RouterLink,HomeComponent],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  register : any

  constructor(private fb: FormBuilder){
    this.register = this.fb.group({
      fullName : [''],
      email : [''],
      password : [''], 
      role : [0]    
    })
  }

  onSubmit(){
    console.log(this.register.value)
  }
}
