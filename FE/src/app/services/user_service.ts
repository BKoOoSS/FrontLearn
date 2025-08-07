import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../models/user";
import { BehaviorSubject, Observable } from "rxjs";
import { Router } from "@angular/router";

@Injectable({ providedIn: "root" })
export class AuthService {
    private baseUrl = "http://localhost:5000/api/user";

    constructor(private http: HttpClient, private router: Router) {}

    login(data: User): Observable<User> {
        return this.http.post<User>(`${this.baseUrl}/login`, data);
    }

    register(data: User): Observable<User> {
        return this.http.post<User>(`${this.baseUrl}/register`, data);
    }
}
