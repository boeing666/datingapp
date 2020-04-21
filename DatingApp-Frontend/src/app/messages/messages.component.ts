import {Component, OnInit} from '@angular/core';
import {User} from '../../_models/user';
import {UserService} from '../../services/user.service';
import {AlertifyService} from '../../services/alertify.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {
  constructor() {
  }
  ngOnInit(): void {
  }
}
