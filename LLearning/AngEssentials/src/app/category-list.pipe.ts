import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'categoryList',
    pure: true // Indicates if the pipe maintains state
})
export class CategoryListPipe implements PipeTransform {
    transform(mediaItems) {
        const categories = [];
        mediaItems.forEach(mediaItem => {
            if(categories.indexOf(mediaItem.category) <= -1) {
                categories.push(mediaItem.category);
            }
        });

        return categories;
    }
}