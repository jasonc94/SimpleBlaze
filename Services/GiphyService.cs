using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SimpleBlazorApp.Config;
using SimpleBlazorApp.Models;
using System.Text;

namespace SimpleBlazorApp.Services
{
	public interface IGiphyService
	{
		Task<GiphyResponse> Serach(string search);
		Task<GiphyResponse> Trending(int offset = 0);
	}
	public class GiphyService : IGiphyService
	{
		private HttpClient _httpClient;
		private IOptions<GiphyConfig> giphyConfig;
		private ILogger<GiphyService> _logger;

		public GiphyService(IHttpClientFactory httpClientFactory, IOptions<GiphyConfig> giphyConfig, ILogger<GiphyService> logger)
		{
			_httpClient = httpClientFactory.CreateClient("Giphy");
			this.giphyConfig = giphyConfig;
			_logger = logger;
		}

		public async Task<GiphyResponse> Serach(string search)
		{
			try
			{
				var request = CreateRequest(HttpMethod.Get, $"gifs/search?q={search}");
				var response = await _httpClient.SendAsync(request);
				var giphyResponse = await response.Content.ReadFromJsonAsync<GiphyResponse>();
				return giphyResponse;
			}
			catch (Exception ex) { 
				_logger.LogError(ex, ex.Message);
				return null;
			}
		}

		public async Task<GiphyResponse> Trending(int offset = 0)
		{
			try
			{
				var request = CreateRequest(HttpMethod.Get, $"gifs/trending?offset={offset}");
				var response = await _httpClient.SendAsync(request);
				var giphyResponse = await response.Content.ReadFromJsonAsync<GiphyResponse>();
				return giphyResponse;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return null;
			}
		}

		private HttpRequestMessage CreateRequest(HttpMethod method, string endpoint, object? requestPayload = null) {
			var requestUri = $"{giphyConfig.Value.BaseUrl}/{endpoint}";
			if (requestPayload != null) {
				var stringContent = JsonConvert.SerializeObject(requestPayload);
				return new(method, requestUri)
				{
					Content = new StringContent(stringContent, Encoding.UTF8, "application/json")
				};
			}
			return new(method, requestUri);
		}
	}
}
