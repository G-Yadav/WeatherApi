using com.weather.business;
using com.weather.business.interfaces;
using com.weather.domain;
using Microsoft.AspNetCore.Mvc;

namespace com.weather.api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get(string city)
    {
        var ci =  new City() {
            Name = city
        };
        var result = await _weatherService.GetCurrentWeatherForAsync(ci);
        var res = new List<WeatherForecast>
        {
            result
        };
        
        return res.ToArray();
    }
}
