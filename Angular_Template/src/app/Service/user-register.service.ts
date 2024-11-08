import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SignUp } from '../models/models.module';

@Injectable({
  providedIn: 'root'
})
export class UserRegisterService {

  constructor(private http : HttpClient) { }

  userRegisterUrl : string = "http://localhost:5185/api/UserLogins";

  registerUser(userObj : SignUp){
   return this.http.post(this.userRegisterUrl ,userObj);
  }

  UserSignIn(UserSignIn:any){
    return this.http.post(this.userRegisterUrl + '/login' , UserSignIn)
  }
}
