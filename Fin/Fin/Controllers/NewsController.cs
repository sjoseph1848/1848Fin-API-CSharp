using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Formatters;
using Fin.Models.Models.News;
using Microsoft.Extensions.Configuration;

namespace Fin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        public NewsController(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }


        [HttpGet]
        public async Task<IActionResult> GetNews()
        {
            string uri = $"top-headlines?country=us&category=business&apiKey={_config["NewsKey"]}";
            var client = _clientFactory.CreateClient(
                name: "NewsService");
            var request = new HttpRequestMessage(
                method: HttpMethod.Get, requestUri: uri);

            HttpResponseMessage response = await client.SendAsync(request);

            string jsonString = await response.Content.ReadAsStringAsync();

            NewsDto model = JsonConvert.DeserializeObject<NewsDto>(jsonString);

            return Ok(model);
        }

    }
}