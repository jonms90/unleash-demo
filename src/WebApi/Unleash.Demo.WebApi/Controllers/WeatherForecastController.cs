using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.FeatureToggles;

namespace Unleash.Demo.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IFeatureToggler _featureToggler;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IFeatureToggler featureToggler)
        {
            _logger = logger;
            _featureToggler = featureToggler;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetByUser(string userId)
        {
            var rng = new Random();
            var includeSummary = _featureToggler.IsEnabled(
                FeatureToggles.WeatherForecast_IncludeSummary.ToString(),
                new FeatureToggleContext {UserId = userId});

            return Enumerable.Range(1, 5).Select(index =>
                {
                    var forecast = new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                    };

                    if (includeSummary)
                    {
                        forecast.Summary = Summaries[rng.Next(Summaries.Length)];
                    }

                    return forecast;
                })
                .ToArray();
        }
    }
}
