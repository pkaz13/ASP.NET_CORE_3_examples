using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Autofac_net_core_3_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public string Get()
        {
            return _weatherService.GetWeather();
        }
    }
}
