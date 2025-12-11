using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace WeatherAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
   

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;
    private readonly IConfiguration _config;

    /* Basic Usage of HttpClient
    private readonly IHttpClientFactory _httpClientFactory;
    

   //using HttpClientFactory
   public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory)
   {
       _logger = logger;
       _httpClientFactory = httpClientFactory;

   }*/

    public WeatherForecastController(ILogger<WeatherForecastController> logger , IWeatherService weatherService, IConfiguration config)
    {
        _logger = logger;
        _weatherService = weatherService;
        _config = config;

    }

   [HttpGet(Name = "GetWeatherForecast")]
   public async Task<string> Get()
   {
        /* Basic Usage of HttpClient
        var httpClient = _httpClientFactory.CreateClient();
        var URL = $"http://api.weatherapi.com/v1/current.json?key=4eb744e0d9bb4a27bbc75712250912&q={cityName}";
        var response = await httpClient.GetAsync(URL);
        return  await response.Content.ReadAsStringAsync();
        */
        // Always get the cityName: first from query, fallback to appsettings.json
        var query = HttpContext.Request.Query;
        string cityName = query.ContainsKey("cityName")
                          ? query["cityName"].ToString()
                          : _config["cityName"];

        return await _weatherService.Get(cityName);


}
}

