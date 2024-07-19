import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WeatherComponent } from './weather/weather.component';
import { RouterModule, Routes } from '@angular/router';
import { provideInitialTheme } from '@skyux/theme';
import { SkyNavbarModule } from '@skyux/navbar';
import { NavigationComponent } from './navigation/navigation.component';
import { SkyLookupModule } from '@skyux/lookup';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SkyAlertModule, SkyIconModule, SkyKeyInfoModule, SkyWaitModule } from '@skyux/indicators';
import { SkyInputBoxModule } from '@skyux/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { WeatherCardComponent } from './weather-card/weather-card.component';
import { SkyBoxModule, SkyDescriptionListModule, SkyFluidGridModule } from '@skyux/layout';
import { SkyDatePipeModule } from '@skyux/datetime';
import { SkyToastModule } from '@skyux/toast';


const routes: Routes = [
  { path: '', redirectTo: '/weather', pathMatch: 'full' },
  { path: 'weather', component: WeatherComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    WeatherComponent,
    NavigationComponent,
    WeatherCardComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(routes),
    AppRoutingModule,
    SkyNavbarModule,
    SkyLookupModule,
    ReactiveFormsModule,
    HttpClientModule,
    SkyWaitModule,
    SkyInputBoxModule,
    SkyBoxModule,
    SkyDescriptionListModule,
    SkyFluidGridModule,
    SkyIconModule,
    SkyKeyInfoModule,
    SkyAlertModule,
    SkyDatePipeModule,
    SkyToastModule
  ],
  providers: [
    provideInitialTheme('modern')
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
