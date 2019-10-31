import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'mw-media-item',
  templateUrl: './media-item.component.html',
  styleUrls: ['./media-item.component.css']
})
export class MediaItemComponent {
  // Sample code
  // name = 'The Redemption';
  // wasWatched() {
  //   return true;
  // }
  onDelete(){
    console.log("deleted");
    this.delete.emit(this.mediaItem);
  }

  // @Input specifies what can be given as input to the selector element
  @Input() mediaItem;

  // @Output allows you to expose event bindings on components
  @Output() delete = new EventEmitter();
}
