
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
        public IEnumerable<IndexDetailDto> GetCurrentYear(IndexDetailDto[] format)
        {
            var early = new DateTime(2020, 01, 01);
            var filtered = format.Where(f => f.Date > early);

            return filtered;
         
        }
    }
}
