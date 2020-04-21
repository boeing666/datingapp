import {Injectable} from '@angular/core';
import {User} from '../_models/user';
import {ActivatedRouteSnapshot, Resolve, Router} from '@angular/router';
import {Observable, of} from 'rxjs';
import {UserService} from '../services/user.service';
import {AlertifyService} from '../services/alertify.service';
import {catchError} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MemberListResolver implements Resolve<User[]> {
  constructor(private userService: UserService,
              private route: Router, private alertify: AlertifyService) {
  }

  resolve(route: ActivatedRouteSnapshot): Observable<User[]> {
    return this.userService.getUsers().pipe(
      catchError(err => {
        this.alertify.error('Problem retrieving data');
        this.route.navigate(['/home']);
        return of(null);
      })
    );
  }

}
