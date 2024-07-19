using WebApi.ApiServices;
using WebApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

 builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost4200",
                builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });

builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add application services
builder.Services.AddTransient<IWeatherForecastApiService, WeatherForecastApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost4200");

app.UseAuthorization();

app.MapControllers();

app.Run();
