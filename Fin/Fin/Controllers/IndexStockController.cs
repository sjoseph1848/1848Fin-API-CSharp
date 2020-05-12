using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fin.BL;
using Fin.BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexStockController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetIndex()
        {
            using (var client = new HttpClient())
            {
                var url = new Uri("https://financialmodelingprep.com/api/v3/historical-price-full/index/%5EGSPC");
                var response = await client.GetAsync(url);
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                var stock = JsonConvert.DeserializeObject<IndexDto>(json);
                return Ok(stock);
            }
        }
    }
}