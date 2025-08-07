import { Component } from "@angular/core";
import { User } from "../models/user";
import { AuthService } from "../services/user_service";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

@Component({
  selector: "app-register",
  imports: [CommonModule, FormsModule],
  templateUrl: "./register.component.html",
  styleUrl: "./register.component.scss",
})
export class RegisterComponent {
  data: User = { id: 0, email: "", password: "", username: "" };

  constructor(private userService: AuthService) {}

  register() {
    this.userService.register(this.data).subscribe({
      next: (response) => {
        console.log("Registration successful", response);
        // Handle successful login, e.g., redirect to dashboard
      },
      error: (error) => {
        console.error("Registration failed", error);
        // Handle login error, e.g., show an error message
      },
    });
  }
}
