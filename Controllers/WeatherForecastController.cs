using IService;
using Microsoft.AspNetCore.Mvc;
using ReadSite.util;
using Service;

namespace WebReadSite.Controllers
{
    /// <summary>
    /// 天气
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(ApiVersion.V1))]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBookService _bookService;
        /// <summary>
        /// 1
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="bookService"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }
        /// <summary>
        /// 获取天气
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

       
       

    }
}
