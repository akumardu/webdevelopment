import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { MediaItemFormComponent } from './media-item-form.component';
import { newItemRouting } from './new-item.routing';

// Breaking angular app into feature modules allows us to use lazy loading
// where angular delivers modules only when needed
@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        FormsModule,
        newItemRouting
    ],
    declarations: [
        MediaItemFormComponent
    ]
})
export class NewItemModule{}