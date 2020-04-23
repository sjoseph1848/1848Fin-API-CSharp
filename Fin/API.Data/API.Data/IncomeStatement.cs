using API.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API.Data
{
    public class IncomeStatement
    {
    
        private static HttpClient _httpClient = new HttpClient();
        public IncomeStatement()
        {
            _httpClient.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/financials/income-statement/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task Run()
        {
            await GetIncomeStatements();
        }

        public async Task GetIncomeStatements()
        {

            var response = await _httpClient.GetAsync("AAPL");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var incomeStatement = new List<IncomeStatementDto>();
            //incomeStatement = JsonConvert.DeserializeObject<List<>>(content);

            //var request = new HttpRequestMessage(HttpMethod.Get, "AAPL");
            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var response = await _httpClient.SendAsync(request);

            //response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();
            //var incomeStatements = JsonConvert.DeserializeObject<List<IncomeStatementDto>>(content);

            //return incomeStatements;
        }
    }
}
