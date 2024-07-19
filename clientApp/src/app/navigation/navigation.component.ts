import { Component } from '@angular/core';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent {
  navigationList = [
    {id: 'weatherForecast', routerLink: '/', name: 'Weather Forecast', active:false},
    {id: 'home', routerLink: '/', name: 'Home', active:true},
    {id: 'features', routerLink: '/', name: 'Features', active:false}
  ];

  navItemClicked(item: any) {
    this.navigationList.forEach(element => element.active = false);
    if(item && item.id != 'weatherForecast'){
      item.active = !item.active;
    }
    else{
      this.navigationList[1].active = true;
    }
  }
}
