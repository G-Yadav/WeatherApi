using com.weather.domain;

namespace com.weather.business.interfaces;

public interface IWeatherService 
{
    Task<WeatherForecast> GetCurrentWeatherForAsync(City city);
}

