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
       
       public async Task<IndexDto> ReturnIndex()
        {
            using(var client = new HttpClient())
            {
                var url = new Uri("https://financialmodelingprep.com/api/v3/historical-price-full/index/%5EGSPC");
                var response = await client.GetAsync(url);
                string json;
                using(var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                return JsonConvert.DeserializeObject<IndexDto>(json);
            }
        }
    }
}
