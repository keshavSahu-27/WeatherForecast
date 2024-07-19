import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { WeatherService } from '../services/weather.service';
import { SkyWaitService } from '@skyux/indicators';
import { SkyAutocompleteSearchAsyncArgs, SkyLookupShowMoreConfig } from '@skyux/lookup';
import { catchError, debounceTime, delay, distinctUntilChanged, map, switchMap, tap } from 'rxjs/operators';
import { of } from 'rxjs';
import { Location } from '../shared/interfaces';
import { SkyToastService, SkyToastType } from '@skyux/toast';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss'],
})
export class WeatherComponent implements OnInit {
  constructor(
    private weatherService: WeatherService,
    private skyToastService: SkyToastService
  ) {}

  form: FormGroup | null = null;
  selectedLocation : Location | null = null;

  public ngOnInit(): void {
    this.form = new FormGroup({
      location: new FormControl<Location[] | null>(null),
    });

    this.form.valueChanges.subscribe(x => {
      this.selectedLocation = this.form?.get('location')?.value[0];
    });
  }

  protected searchAsync(args: SkyAutocompleteSearchAsyncArgs): void {
    this.selectedLocation = null;
    args.result = of(args.searchText).pipe(
      debounceTime(500),
      distinctUntilChanged(),
      switchMap(searchText => this.weatherService.getLocations(searchText)
        .pipe(catchError(err => {
          this.skyToastService.openMessage('An error occured while fetching data.', {
            type: SkyToastType.Danger,
          });
          console.log(err);
          return of({value : []});
        }))
      ),
      map(result => ({
        items: result.value,
        totalCount: result.value.length
      }))
    );
  }
}
