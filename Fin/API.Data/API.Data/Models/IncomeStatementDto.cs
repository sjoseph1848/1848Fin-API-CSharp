﻿using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.Models
{
    public class IncomeStatementDto
    {
        public string symbol { get; set; }

        public IncomeStatementDetailDto[] financials {get;set;}
        
    }
}
