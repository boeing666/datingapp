import {Component, OnInit} from '@angular/core';
import {AuthService} from '../../services/auth.service';
import {AlertifyService} from '../../services/alertify.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  model: any = {};

  constructor(public authService: AuthService,
              private alertify: AlertifyService) {
  }

  ngOnInit(): void {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
        this.alertify.success('logged in successfully');
      }, error => {
       this.alertify.error(error);
      }
    );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logout');
  }
}
