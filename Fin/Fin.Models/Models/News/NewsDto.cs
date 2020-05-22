using System;
using System.Collections.Generic;
using System.Text;

namespace Fin.Models.Models.News
{
    public class NewsDto
    {
        public string Status { get; set; }

        public int TotalResults { get; set; }
        public NewsArticlesDto[] articles { get; set; }
    }
}
