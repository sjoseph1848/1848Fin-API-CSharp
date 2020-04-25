using System;
using System.Collections.Generic;
using System.Text;

namespace Fin.BL.Models
{
    public class IncomeStatementDto
    {
        public string symbol { get; set; }

        public IncomeStatementDetailDto[] financials {get;set;}
        
    }
}
