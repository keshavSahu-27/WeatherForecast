import { Component, Input, OnChanges } from '@angular/core';
import { Location, WeatherForecast } from '../shared/interfaces';
import { WeatherService } from '../services/weather.service';
import { SkyToastService, SkyToastType } from '@skyux/toast';

@Component({
  selector: 'app-weather-card',
  templateUrl: './weather-card.component.html',
  styleUrl: './weather-card.component.scss'
})
export class WeatherCardComponent implements OnChanges {
  @Input() selectedLocation: Location | null = null;
  weatherForeCastData: WeatherForecast | null = null;
  fetchDataForDays = 7 //By Default for now
  isWaiting = false;

  constructor(private weatherService: WeatherService, 
    private skyToastService: SkyToastService
  ) { }

  ngOnChanges() {
    this.reset();
  }

  reset() :void {
    this.weatherForeCastData = null;
    this.getWeatherForecast();
  }

  async getWeatherForecast(): Promise<void> {
    try {
      if(!this.selectedLocation) return;
      this.isWaiting = true;
      let latitude = this.selectedLocation?.latitude ?? 0;
      let longitude = this.selectedLocation?.longitude ?? 0;
      let data = await this.weatherService.getWeatherForcast(latitude, longitude, this.fetchDataForDays).toPromise();
      this.weatherForeCastData = data?.value ?? null;
      this.isWaiting = false;
    }
    catch(ex){
      this.isWaiting = false;
      this.skyToastService.openMessage('An error occured while fetching forecast.', {
        type: SkyToastType.Danger,
      });
      console.log(ex); 
    }
  }

  ngOnDestroy(){
    this.weatherForeCastData = null;
  }
}
