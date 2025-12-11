using System;
namespace WeatherAPI
{
	public interface IWeatherService
	{
		Task<string> Get(string cityName);
	}

	public class WeatherService : IWeatherService
	{
		private HttpClient _httpClient;
		private readonly string _apiKey;

		public WeatherService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_apiKey = configuration["apiKeyStore"];
		}

		public async Task<string> Get(string cityName)
		{
			var apiKey = _apiKey;

			string APIURL = $"?key={apiKey}&q={cityName}";

			var response = await _httpClient.GetAsync(APIURL);
			return await response.Content.ReadAsStringAsync();

        }
		
	}
}

