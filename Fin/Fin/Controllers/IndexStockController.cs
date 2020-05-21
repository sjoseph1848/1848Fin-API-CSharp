using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fin.Biz;
using Fin.Models;
using Fin.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Fin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexStockController : ControllerBase
    {
        private IndexStock _stockFormatter;
        private readonly IConfiguration _config;
        public IndexStockController(IndexStock stockFormatter, IConfiguration config)
        {

            _stockFormatter = stockFormatter;
            _config = config;
        }

        [HttpGet("{symbol}")]
        public async Task<IActionResult> GetIndex(string symbol)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"https://financialmodelingprep.com/api/v3/historical-price-full/index/{symbol}?apikey={_config["FinKey"]}");
                var response = await client.GetAsync(url);
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                IndexDto stock = JsonConvert.DeserializeObject<IndexDto>(json);
                var format = stock.Historical;
                var newFormat = _stockFormatter.GetMonthlyAverage(format);
                return Ok(newFormat);
            }
        }

        [HttpGet("current/{symbol}")]
        public async Task<IActionResult> GetCurrentIndex(string symbol)
        {
            using(var client = new HttpClient())
            {
                var url = new Uri($"https://financialmodelingprep.com/api/v3/historical-chart/1min/{symbol}?apikey={_config["FinKey"]}");
                var response = await client.GetAsync(url);
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                var currentIndex = JsonConvert.DeserializeObject<List<IndexCurrentDetailDto>>(json);
                var formatCurrentIndex = _stockFormatter.GetCurrentIndexAmount(currentIndex);
               
                return Ok(formatCurrentIndex);
            }
        }
    }
}