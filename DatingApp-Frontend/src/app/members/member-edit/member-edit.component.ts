import {Component, OnInit, ViewChild} from '@angular/core';
import {User} from '../../../_models/user';
import {ActivatedRoute} from '@angular/router';
import {AlertifyService} from '../../../services/alertify.service';
import {NgForm} from '@angular/forms';
import {UserService} from '../../../services/user.service';
import {AuthService} from '../../../services/auth.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  user: User;
  @ViewChild('editForm') editForm: NgForm;

  constructor(private route: ActivatedRoute,
              private alertify: AlertifyService,
              private userService: UserService, private auth: AuthService) {
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.user = data['resolvedUser'];
    });
  }

  updateUser() {
    this.userService.updateUser(this.auth.decodedToken.nameid, this.user).subscribe(next => {
      this.alertify.success('Changes Saved Successfully');
      this.editForm.reset(this.user);
    }, error => {
      this.alertify.error(error);
    });

  }
}
