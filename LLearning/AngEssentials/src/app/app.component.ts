import { Component } from '@angular/core';

@Component({
    selector: 'app-root',
    // either use template or template URL
    // template: '<h1>My App</h1>'
    templateUrl: './app.component.html',
    // styles could also be specified via URLs
    // styles: [`
    // h1 {color: #ffffff;}
    // .description {
    //     font-style: italic;
    //     color: green;
    // }
    // `]
    styleUrls: ['./app.component.css']
})
export class AppComponent{}