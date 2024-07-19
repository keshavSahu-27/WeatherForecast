using Microsoft.AspNetCore.Mvc;
using WebApi.ApiServices;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/weather")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastApiService _service;

    public WeatherForecastController(IWeatherForecastApiService service)
    {
        _service = service;
    }

    [HttpGet("getlocations")]
    public async Task<IResult> GetLocations([FromQuery] string searchTerm)
    {
        var locations = await _service.GetLocationsAsync(searchTerm);
        return Results.Json(statusCode: locations.StatusCode, data: locations.Result);
    }

    [HttpGet("weatherforecast")]
    public async Task<IResult> GetWeatherForecastAsync([FromQuery] double lat, double lon, int days)
    {
        var locations = await _service.GetWeatherForecastAsync(lat, lon, days);
        return Results.Json(statusCode: locations.StatusCode, data: locations.Result);
    }
}
