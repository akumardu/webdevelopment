import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { MediaItemFormComponent } from './media-item-form.component';
import { newItemRouting } from './new-item.routing';

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