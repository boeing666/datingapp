import {Injectable} from '@angular/core';
import {User} from '../_models/user';
import {ActivatedRouteSnapshot, Resolve, Router} from '@angular/router';
import {UserService} from '../services/user.service';
import {AlertifyService} from '../services/alertify.service';
import {Observable, of} from 'rxjs';
import {catchError} from 'rxjs/operators';
import {AuthService} from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})

export class MemberEditResolver implements Resolve<User> {
  constructor(private userService: UserService, private router: Router,
              private alertifyService: AlertifyService, private auth: AuthService) { }

  resolve(route: ActivatedRouteSnapshot): Observable<User> {
    console.log(this.auth.decodedToken.nameId);
    return this.userService.getUser(this.auth.decodedToken.nameid).pipe(
      catchError(error => {
        this.alertifyService.error('Problem retrieving your data');
        this.router.navigate(['/members']);
        return of(null);
      })
    );
  }
}
