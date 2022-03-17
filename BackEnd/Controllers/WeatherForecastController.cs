using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FrontEndApi.Controllers
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

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
      var wf = Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
      })
      .ToArray();

      foreach (var w in wf)
      {
        w.Summary = getSummary(w.TemperatureC);
      }

      return wf;
    }

    private string getSummary(int temp)
    {
      if (temp < -13) return Summaries[0];
      if (temp < -5) return Summaries[1];
      if (temp < 3) return Summaries[2];
      if (temp < 10) return Summaries[3];
      if (temp < 18) return Summaries[4];
      if (temp < 25) return Summaries[5];
      if (temp < 33) return Summaries[6];
      if (temp < 40) return Summaries[7];
      if (temp < 48) return Summaries[8];
      return Summaries[9];
    }
  }
}