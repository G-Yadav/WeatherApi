using com.weather.business.infrastructure;
using com.weather.business.interfaces;
using com.weather.domain;

namespace com.weather.business;

public class WeatherService : IWeatherService
{
    private readonly IRealtimeApiWrapper _realtimeApi;

    public WeatherService(IRealtimeApiWrapper realtimeApi)
    {
        _realtimeApi = realtimeApi;
    }

    public async Task<WeatherForecast> GetCurrentWeatherForAsync(City city)
    {
        return await _realtimeApi.GetRealtimeWeatherAsync(city);
    }
}
