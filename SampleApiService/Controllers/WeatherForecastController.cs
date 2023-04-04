using Microsoft.AspNetCore.Mvc;

namespace SampleApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Post([FromBody] int dataLimit)
        {
            var forecastData = new List<WeatherForecast>();
            var limit = dataLimit;
            var tempC = 0;

            for (int i = 0; i < limit; i++)
            {
                tempC = Random.Shared.Next(-20, 55);
                forecastData.Add(new()
                {
                    Timestamp = DateTime.Now.ToString(),
                    Summary = $"Forecast {i}",
                    TemperatureC = tempC,
                    TemperatureF = 32 + (int)(tempC / 0.5556)
                });
            }

            return forecastData;
        }
    }
}
