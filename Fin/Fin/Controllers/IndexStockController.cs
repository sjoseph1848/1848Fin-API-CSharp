using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fin.Biz;
using Fin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexStockController : ControllerBase
    {
        private IndexStock _stockFormatter;
        public IndexStockController(IndexStock stockFormatter)
        {
            _stockFormatter = stockFormatter;
        }

        [HttpGet("{symbol}")]
        public async Task<IActionResult> GetIndex(string symbol)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"https://financialmodelingprep.com/api/v3/historical-price-full/index/{symbol}");
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
    }
}