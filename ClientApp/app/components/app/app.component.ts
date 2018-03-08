import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    css: any = null;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        this.fetchCss();
    }


    fetchCss() {
        this.http.get(this.baseUrl + '/CustomCss/').subscribe(result => {
            this.css = result;
        }, error => console.error(error));
    }
}
