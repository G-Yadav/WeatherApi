using com.weather.business;
using com.weather.business.infrastructure;
using com.weather.business.interfaces;
using com.weather.infrastructure.extensions;
using com.weather.infrastructure.wrapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApiKeyOptions>(builder.Configuration.GetSection(ApiKeyOptions.OptionName));
builder.Services.AddHttpClient("WeatherApi",_client => {
    _client.BaseAddress = new Uri("https://api.weatherapi.com/v1/");
}).AddHttpMessageHandler<HttpMessageHandlers>();

builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IRealtimeApiWrapper, RealtimeApiWrapper>();
builder.Services.AddScoped<HttpMessageHandlers>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
