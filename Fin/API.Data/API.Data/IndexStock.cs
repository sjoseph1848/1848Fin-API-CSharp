using Fin.BL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fin.BL
{
    public class IndexStock
    {
        public async Task<IndexDto> GetIndexAsync()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/historical-price-full/index/");
                client.Timeout = new TimeSpan(0, 0, 30);
                client.DefaultRequestHeaders.Clear();
                var response = await client.GetAsync("%5EGSPC");
                string json;
                //if(response.EnsureSuccessStatusCode())
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }               
                return JsonConvert.DeserializeObject<IndexDto>(json);
            }
        }
    }
}
