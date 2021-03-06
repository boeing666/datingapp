import {Component, OnInit} from '@angular/core';
import {AuthService} from '../../services/auth.service';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;

  constructor(private https: HttpClient) {
  }

  ngOnInit(): void {
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }


  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }
}
