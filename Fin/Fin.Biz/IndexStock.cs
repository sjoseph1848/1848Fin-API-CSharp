
using Fin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Fin.Biz
{
    public class IndexStock
    {


        public IEnumerable<IndexDetailDto> GetMonthlyAverage(IndexDetailDto[] format)
        {
            var monthlyAverages = new List<IndexDetailDto>();
            var currentYear = GetCurrentYear(format);

            // Todo: add select method to create new IndexDetail Dto 
            decimal januaryAvg = currentYear.Where(d => d.Date >= new DateTime(2020, 01, 01) && d.Date <= new DateTime(2020, 01, 31)).Average(c => c.Open);
            decimal februaryAvg = currentYear.Where(d => d.Date >= new DateTime(2020, 02, 01) && d.Date <= new DateTime(2020, 02, 20)).Average(c => c.Open);
            decimal marchAvg = currentYear.Where(d => d.Date >= new DateTime(2020, 03, 01) && d.Date <= new DateTime(2020, 03, 31)).Average(c => c.Open);
            decimal aprilAvg = currentYear.Where(d => d.Date >= new DateTime(2020, 04, 01) && d.Date <= new DateTime(2020, 04, 30)).Average(c => c.Open);
            decimal mayAvg = currentYear.Where(d => d.Date >= new DateTime(2020, 05, 01) && d.Date <= new DateTime(2020, 05, 31)).Average(c => c.Open);
            
            // Todo: update this to use a foreach to loop over and breakout into another method. Just want it to work for present time. 
            var january = new IndexDetailDto
            {
                Date = new DateTime(2020, 01,01),
                Open = januaryAvg
            };

            var february = new IndexDetailDto
            {
                Date = new DateTime(2020, 02, 01),
                Open = februaryAvg
            };

            var march = new IndexDetailDto
            {
                Date = new DateTime(2020, 03, 01),
                Open = marchAvg
            };

            var april = new IndexDetailDto
            {
                Date = new DateTime(2020, 04, 01),
                Open = aprilAvg
            };

            var may = new IndexDetailDto
            {
                Date = new DateTime(2020, 05, 01),
                Open = mayAvg
            };


            // Todo:  Create another method to handle this as well 
            monthlyAverages.Add(january);
            monthlyAverages.Add(february);
            monthlyAverages.Add(march);
            monthlyAverages.Add(april);
            monthlyAverages.Add(may);

            return monthlyAverages;
        }



        private IEnumerable<IndexDetailDto> GetCurrentYear(IndexDetailDto[] format)
        {
            var early = new DateTime(2020, 01, 01);
            var filtered = format.Where(f => f.Date > early);

            return filtered;
         
        }
    }
}
