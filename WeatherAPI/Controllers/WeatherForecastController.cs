using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace WeatherAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
   

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
   
    //using HttpClientFactory
    public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
      
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<string> Get(string cityName)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var URL = $"http://api.weatherapi.com/v1/current.json?key=4eb744e0d9bb4a27bbc75712250912&q={cityName}";
        var response = await httpClient.GetAsync(URL);
        return  await response.Content.ReadAsStringAsync();
        

       
    }
}

