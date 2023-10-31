using System.Collections.Specialized;
using System.Web;
using Microsoft.Extensions.Options;

namespace com.weather.infrastructure.extensions;

public class HttpMessageHandlers : DelegatingHandler
{
    private readonly ApiKeyOptions _apiKey;

    public HttpMessageHandlers(IOptions<ApiKeyOptions> options)
    {
        _apiKey = options.Value;
    }

    protected async override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (_apiKey != null && _apiKey.ApiKey != null && request != null && request.RequestUri != null)
        {
            NameValueCollection nameValue = HttpUtility.ParseQueryString(request.RequestUri.Query.ToString());
            nameValue.Add("key", _apiKey.ApiKey.ToString());
            var uri = new UriBuilder
            {
                Path = request.RequestUri.AbsolutePath,
                Query = nameValue.ToString(),
                Host = request.RequestUri.Host
            };

            request.RequestUri = uri.Uri;
        }

        return await base.SendAsync(request, cancellationToken);
    }
}