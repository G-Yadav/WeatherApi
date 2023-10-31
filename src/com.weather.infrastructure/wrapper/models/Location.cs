using System.Text.Json.Serialization;

namespace com.weather.infrastructure.models;

public class Location
{
    [JsonPropertyName("lat")]
    public decimal Latitude {get; set;}
    [JsonPropertyName("lon")]
    public decimal Longitude {get; set;}
    [JsonPropertyName("name")]
    public string? Name  {get; set;}
    [JsonPropertyName("region")]
    public string? Region  {get; set;}
    [JsonPropertyName("country")]
    public string? Country {get; set;}
    [JsonPropertyName("tz_id")]
    public string? Timezone_id {get; set;}
    [JsonPropertyName("localtime_epoch")]
    public int Localtime_epoch {get; set;}
    [JsonPropertyName("localtime")]
    public string? Localtime {get; set;}
}
