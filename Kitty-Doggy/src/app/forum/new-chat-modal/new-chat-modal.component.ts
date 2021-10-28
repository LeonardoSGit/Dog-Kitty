import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSpinnerComponent } from 'src/app/mat-spinner/mat-spinner.component';
import { ChatService } from 'src/app/services/chat.service';
import { RacaService } from 'src/app/services/raca.service';
import { Chat } from 'src/domain/chat';
import { Filtro } from 'src/domain/filtro';

@Component({
  selector: 'app-new-chat-modal',
  templateUrl: './new-chat-modal.component.html',
  styleUrls: ['./new-chat-modal.component.css']
})
export class NewChatModalComponent implements OnInit {

  form: FormGroup;
  localizacao:string;
  racas: any;
  constructor(
      private fb: FormBuilder,
      public dialog: MatDialog,
      public chatService: ChatService,
      private dialogRef: MatDialogRef<NewChatModalComponent>,
      @Inject(MAT_DIALOG_DATA) {title}) {
        this.form = fb.group({
          title: [title]
        });

  }

  ngOnInit() {

  }
  
  save() {
    var chat = new Chat();
    chat.Date = new Date();
    chat.Title = this.form.value.title;
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.chatService.createChat(chat).subscribe(()=>{
      
      this.dialogRef.close(this.form.value);
      dialogRef.close();
    },error=>{ dialogRef.close();});
  }

  close() {
      this.dialogRef.close();
  }
}
