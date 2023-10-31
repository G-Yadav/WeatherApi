using System.Net.Sockets;

namespace com.weather.infrastructure.extensions;

public class ApiKeyOptions
{
    public static string OptionName => "apikey";
    public string? ApiKey {get; set;}
}