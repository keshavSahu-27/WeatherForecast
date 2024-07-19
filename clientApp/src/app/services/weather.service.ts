import { HttpClient, HttpClientModule, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiResponse, Location, WeatherForecast } from '../shared/interfaces';
import { baseLocation } from '../shared/constants';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  constructor(private http: HttpClient) { }

  getLocations(searchTerm: string): Observable<ApiResponse<Location[]>> {
    let params = new HttpParams()
      .set('searchTerm', searchTerm);
    return this.http.get<ApiResponse<Location[]>>(`${baseLocation}/api/weather/getlocations`, { params: params });
  }

  getWeatherForcast(latitude: number, longitude: number, days: number): Observable<ApiResponse<WeatherForecast>> {
    let params = new HttpParams()
      .set('lat', latitude.toString())
      .set('lon', longitude.toString())
      .set('days', days.toString());
    return this.http.get<ApiResponse<WeatherForecast>>(`${baseLocation}/api/weather/weatherforecast`, { params: params });
  }
}
