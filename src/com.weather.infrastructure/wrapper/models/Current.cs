using System.Text.Json.Serialization;

namespace com.weather.infrastructure.models;

public class Current
{
    [JsonPropertyName("last_updated")]
    public string? LastUpdated {get; set;}
    [JsonPropertyName("last_updated_epoch")]
    public int LastUpdatedEpoch {get; set;}
    [JsonPropertyName("temp_c")]
    public decimal TempInC {get; set;}
    [JsonPropertyName("temp_f")]
    public decimal TempInF {get; set;}
    [JsonPropertyName("feelslike_c")]
    public decimal FeelsLikeC {get; set;}
    [JsonPropertyName("feelslike_f")]
    public decimal FeelsLikeInF {get; set;}
    [JsonPropertyName("condition")]
    public Condition? Condition {get; set;}
    [JsonPropertyName("wind_mph")]
    public decimal WindInMph {get; set;}
    [JsonPropertyName("wind_kph")]
    public decimal WindInKph {get; set;}
    [JsonPropertyName("wind_degree")]
    public int WindDegree {get; set;}
    [JsonPropertyName("wind_dir")]
    public string? WindDirection {get; set;}
    [JsonPropertyName("pressure_mb")]
    public decimal PressureInmb {get; set;}
    [JsonPropertyName("pressure_in")]
    public decimal PressureInInches {get; set;}
    [JsonPropertyName("precip_mm")]
    public decimal PrecipitationInmm {get; set;}
    [JsonPropertyName("precip_in")]
    public decimal PrecipitationInInches {get; set;}
    [JsonPropertyName("humidity")]
    public int Humidity {get; set;}
    [JsonPropertyName("cloud")]
    public int Cloud {get; set;}
    [JsonPropertyName("is_day")]
    public int IsDay {get; set;}
    [JsonPropertyName("uv")]
    public decimal Uv {get; set;}
    [JsonPropertyName("gust_mph")]
    public decimal WindGustInMph {get; set;}
    [JsonPropertyName("gust_kph")]
    public decimal WindGustInKph {get; set;}
}