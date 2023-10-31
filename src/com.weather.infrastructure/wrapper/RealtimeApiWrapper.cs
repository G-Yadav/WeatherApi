using System.Collections.Specialized;
using System.Text.Json;
using System.Web;
using com.weather.business.infrastructure;
using com.weather.domain;
using com.weather.infrastructure.models;

namespace com.weather.infrastructure.wrapper;

public class RealtimeApiWrapper : IRealtimeApiWrapper
{
    private readonly HttpClient _client;

    public RealtimeApiWrapper(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("WeatherApi");
    }

    public async Task<WeatherForecast> GetRealtimeWeatherAsync(City city)
    {
        NameValueCollection nameValue = HttpUtility.ParseQueryString(string.Empty);
        nameValue.Add("q", city.Name);
        var route = "current.json?"+nameValue.ToString();

        try
        {
            var response = await _client.GetAsync(route);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<RealtimeApiResponse>(content);
            DateTime.TryParse(data?.Location?.Localtime, out DateTime date);

            return new WeatherForecast()
            {
                Date = DateOnly.FromDateTime(date),
                TemperatureC = (int)data?.Current?.TempInC,
                Summary = data?.Location?.Name
            };
        }
        catch (HttpRequestException ex)
        {
            System.Console.WriteLine(ex.Message.ToString());
        }
        return new WeatherForecast();
    }
}
