import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HttpXhrBackend } from '@angular/common/http';
import { AppComponent } from './app.component';
import { MediaItemComponent } from './media-item.component';
import { MediaItemListComponent } from './media-item-list.component';
import { FavoriteDirective } from './favorite.directive';
import { CategoryListPipe } from './category-list.pipe';
import { lookupListToken, lookupLists } from './providers';
import { MockXHRBackend } from './mock-xhr-backend';
import { routing } from './app.routing';
import { CategoryListComponent } from './category-list.component';

// value providers - these are different from media-item.service providers
// const lookupLists = {
//     medium: ['Movies', 'Series']
// };

@NgModule({
    imports: [
        BrowserModule,
        HttpClientModule,
        routing
    ],
    declarations: [
        AppComponent,
        MediaItemComponent,
        MediaItemListComponent,
        FavoriteDirective,
        CategoryListComponent,
        CategoryListPipe
    ],
    providers: [
        {
            provide: lookupListToken, 
            useValue: lookupLists
        },
        {
            provide: HttpXhrBackend,
            useClass: MockXHRBackend
        }
    ],
    bootstrap: [
        AppComponent
    ]
}) 

export class AppModule {}