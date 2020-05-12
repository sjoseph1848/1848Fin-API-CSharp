using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fin.BL;
using Fin.BL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Fin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static HttpClient _httpClient = new HttpClient();
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
        public async Task<IActionResult> GetIncomeStatement()
        {

            _httpClient.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/financials/income-statement/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
            var response = await _httpClient.GetAsync("AAPL");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var incomeStatement = JsonConvert.DeserializeObject<IncomeStatementDto>(content);

            return Ok(incomeStatement);

            //var income = new IncomeStatement();
            //var result = income.Run();

            //return Ok(result);
            //var income = new IncomeStatement();
            //var result = income.Run();

            //return Ok(result);

            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
