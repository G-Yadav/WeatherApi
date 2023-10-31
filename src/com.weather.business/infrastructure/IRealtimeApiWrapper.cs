using com.weather.domain;

namespace com.weather.business.infrastructure;

public interface IRealtimeApiWrapper
{
    Task<WeatherForecast> GetRealtimeWeatherAsync(City city);
}
