import { Component, ViewEncapsulation } from '@angular/core';

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
    styleUrls: ['./app.component.css'],
    // None - all css goes in as written
    // ShadowDom - restructring of the final makeup of css in a way that the 
    // styling will not bleed over. ShadowDom is not available on all browsers
    // Emulated - Do Moduler enhancements. it is default.
    // encapsulation: ViewEncapsulation.None
})
export class AppComponent{
    // firstMediaItem = {
    //     id: 1,
    //     name: 'Firebug',
    //     medium: 'Series',
    //     category: 'Sci-Fi',
    //     year: 2010,
    //     watchedOn: 1294166565384,
    //     isFavorite: false
    // };

    onMediaItemDelete(mediaItem){

    }
}