import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    public themes: Theme[] = [];
    public currentTheme:Theme|null = null;

    public selectedTheme:Theme|null = null;

    public isLoading:boolean=false;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        this.fetchThemes();
    }

    fetchThemes(){
        this.isLoading = true;

        this.http.get(this.baseUrl + 'api/Theme/GetThemes').subscribe(result => {
            this.themes = result.json() as Theme[];
            this.isLoading = false;
        }, error => console.error(error));

        this.http.get(this.baseUrl + 'api/Theme/GetCurrentTheme').subscribe(result => {
            this.currentTheme = result.json() as Theme;
            this.selectedTheme = result.json() as Theme;
        }, error => console.error(error));
    }

    selectTheme(themeToSelect:Theme){
        this.selectedTheme = themeToSelect;
    }

    addNewTheme(){
        let newTheme = <Theme>{fontColor:"", mainColor:"",mainBGColor:"",font:""};

        this.themes.push(newTheme);
        this.selectedTheme = newTheme;
    }

    makeActive(){
        if(this.selectedTheme != null)
        {
            this.isLoading = true;
            this.http.post(this.baseUrl + 'api/Theme/SetCurrentTheme/',this.selectedTheme).subscribe(result => {
                this.fetchThemes();
            }, error => console.error(error));
        }
    }

    saveTheme(){
        if(this.selectedTheme != null)
        {
            this.isLoading = true;
            this.http.post(this.baseUrl + 'api/Theme/SaveTheme',this.selectedTheme).subscribe(result => {
                this.fetchThemes();
            }, error => console.error(error));
        }
    }
}

interface Theme {
    themeId:string;
    fontColor:string;
    mainColor:string;
    mainBGColor:string;
    font:string;
}
