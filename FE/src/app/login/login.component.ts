import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from "@angular/forms";
import { User } from "../models/user";
import React from "react";
import { AuthService } from "../services/user_service";
export interface LoginRequest {
  email: string;
  password: string;
}

@Component({
  selector: "app-login",
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: "./login.component.html",
  styleUrl: "./login.component.scss",
})
export class LoginComponent {
  data: User = { id: 0, email: "", password: "", username: "" };

  constructor(private userService: AuthService) {}

  login() {
    this.userService.login(this.data).subscribe({
      next: (response) => {
        console.log("Login successful", response);
        // Handle successful login, e.g., redirect to dashboard
      },
      error: (error) => {
        console.error("Login failed", error);
        // Handle login error, e.g., show an error message
      },
    });
  }
}
