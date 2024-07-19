export interface Location {
    id: number;
    name: string;
    latitude: number;
    longitude: number;
    elevation: number;
    featureCode: string;
    countryCode: string;
    admin1Id: number;
    admin2Id: number;
    timezone: string;
    population: number;
    countryId: number;
    country: string;
    admin1: string;
    admin2: string;
}

interface DailyUnits {
    time: string;
    temperature2mMax: string;
    temperature2mMin: string;
    apparentTemperatureMax: string;
    apparentTemperatureMin: string;
    precipitationSum: string;
    precipitationProbabilityMax: string;
    averageRelativeHumidity2m: string;
  }
  
  export interface Daily {
    time: string[];
    temperature2mMax: number[];
    temperature2mMin: number[];
    apparentTemperatureMax: number[];
    apparentTemperatureMin: number[];
    precipitationSum: number[];
    precipitationProbabilityMax: number[];
    averageRelativeHumidity2m: number[];
  }
  
  export interface WeatherForecast {
    latitude: number;
    longitude: number;
    generationTimeMs: number;
    utcOffsetSeconds: number;
    timezone: string;
    timezoneAbbreviation: string;
    elevation: number;
    dailyUnits: DailyUnits;
    daily: Daily;
  }
  
  export interface ApiResponse<T> {
    statusCode: number;
    value: T;
  }
  
