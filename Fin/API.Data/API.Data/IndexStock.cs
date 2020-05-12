using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Fin.BL
{
    public class IndexStock
    {
        private static HttpClient _httpClient = new HttpClient();

        public IndexStock()
        {
            _httpClient.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/historical-price-full/index/%5EGSPC");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
        }
    }
}
