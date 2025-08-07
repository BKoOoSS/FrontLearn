import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";

@Component({
  selector: "app-root",
  imports: [RouterOutlet, LoginComponent, RegisterComponent],
  templateUrl: "./app.component.html",
  styleUrl: "./app.component.scss",
})
export class AppComponent {
  title = "API";
}
