using System.Text.Json.Serialization;

namespace com.weather.infrastructure.models;

public class RealtimeApiResponse 
{
    [JsonPropertyName("current")]
    public Current? Current {get; set;}
    [JsonPropertyName("location")]
    public Location? Location {get; set;}
}