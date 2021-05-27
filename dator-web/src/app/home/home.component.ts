import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  
  registerMode = false;
  isClicked = false;

  constructor(private translate: TranslateService) {
    this.translate.setDefaultLang('eng');
}
  ngOnInit(): void {
    
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }
useRuLanguage(): void {
    this.translate.setDefaultLang('ru');
}
useEngLanguage(): void {
  this.translate.setDefaultLang('en');
}


}
