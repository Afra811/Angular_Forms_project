import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Route, Router, RouterLink, RouterModule } from '@angular/router';
import { HomeComponent } from '../Component/home/home.component';
import { UserRegisterService } from '../Service/user-register.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule,CommonModule,RouterLink,RouterModule,HomeComponent],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  register : any;
  Submitted = false;

  constructor(
    private fb: FormBuilder ,
    private userRegisterService : UserRegisterService,
    private toastr: ToastrService,
    private rout: Router){

    this.register = this.fb.group({
      userName : ['',Validators.required],
      email : ['',[Validators.required, Validators.email]],
      password : ['', [Validators.required,Validators.minLength(8)]], 
      confirmPassword: ['', Validators.required],
      role : ['', Validators.required],
      terms: [false,Validators.requiredTrue]    
    })
  }

  get userName() { return this.register.get('userName'); }
  get email() { return this.register.get('email'); }
  get password() { return this.register.get('password'); }
  get confirmPassword() { return this.register.get('confirmPassword'); }
  get role() { return this.register.get('role'); }
  get terms() { return this.register.get('terms'); }


  onSubmit(){
    var user = this.register.value
    var isPasswordMatch : boolean = this.passwordMatch(user.password, this.register.value.confirmPassword)
    if(isPasswordMatch){
      const AddUser:any = {
        userName:user.userName,
        email:user.email,
        password:user.password,
        role:Number(user.role)
      }

    this.userRegisterService.registerUser(AddUser).subscribe({
      next:(response) =>{
        this.toastr.success("User SignUP Successfully..", "",{
          positionClass:"toast-top-right",
          progressBar:true,
          timeOut:4000
        })
      },
      complete:()=>{
        this.rout.navigate(['/login'])
      },error:(error)=>{
        console.log(error)
        this.toastr.warning(error.error,"",{
          positionClass:"toast-top-right",
          progressBar:true,
          timeOut:4000 
        })
      }
    })

    }else{
      this.toastr.warning("password not match.." , "" , {
        positionClass:"toast-top-right",
        progressBar:true,
        timeOut:4000
      })
    }
   
  }

  passwordMatch(password:string , confirmPassword:string):boolean{
    if(password != confirmPassword){
      return false
    }else{
      return true
    }
  }
}
