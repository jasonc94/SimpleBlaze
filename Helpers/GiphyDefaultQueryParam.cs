namespace SimpleBlazorApp.Helpers
{
	public class GiphyDefaultQueryParam : DelegatingHandler
	{
		private readonly IConfiguration _configuration;

		public GiphyDefaultQueryParam(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var query = System.Web.HttpUtility.ParseQueryString(request.RequestUri.Query);

			// Add default query parameters here
			query["api_key"] = _configuration["Giphy:ApiKey"];
			query["rating"] = "g";

			var uriBuilder = new UriBuilder(request.RequestUri)
			{
				Query = query.ToString()
			};

			request.RequestUri = uriBuilder.Uri;

			return await base.SendAsync(request, cancellationToken);
		}
	}
}
