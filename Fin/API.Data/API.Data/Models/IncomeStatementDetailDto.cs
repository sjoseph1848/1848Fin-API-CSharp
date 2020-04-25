using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fin.BL.Models
{
   public class IncomeStatementDetailDto
    {
        public string Date { get; set; }
        public double Revenue { get; set; }

        //[JsonProperty(PropertyName = "Revenue Growth")]
        //public string RevenueGrowth { get; set; }

        //[JsonProperty(PropertyName = "Cost of Revenue")]
        //public string CostRevenue { get; set; }

        //[JsonProperty(PropertyName = "Gross Profit")]
        //public double GrossProfit { get; set; }
        //[JsonProperty(PropertyName = "R&D Expenses")]
        //public string RdExpenses { get; set; }
        //[JsonProperty(PropertyName = "SG&A Expenses")]
        //public string SgExpenses { get; set; }
        //[JsonProperty(PropertyName = "Operating Expenses")]
        //public string OperatingExpenses { get; set; }

        //[JsonProperty(PropertyName = "Operating Income")]
        //public string OperatingIncome { get; set; }

        //[JsonProperty(PropertyName = "Interest Expense")]
        //public string InterestExpense { get; set; }
        //[JsonProperty(PropertyName = "Earnings before Tax")]
        //public string EarningsBeforeTax { get; set; }
        //public string IncomeTaxExpense { get; set; }
        //public string NetIncomeNonControlInterest { get; set; }
        //public string NetIncomeDiscontinuedOperations { get; set; }
        //public string PreferredDividends { get; set; }
        //public string NetIncomeCom { get; set; }
        //public string EPS { get; set; }
        //public string EPSDiluted { get; set; }
        //public string WeightedAvgShsOutstanding { get; set; }
        //public string WeightedAvgShsOutstandingDiluted { get; set; }
        //public string DividendPerShare { get; set; }
        //public string GrossMargin { get; set; }
        //public string EBITDAMargin { get; set; }
        //public string EBITMargin { get; set; }
        //public string ProfitMargin { get; set; }
        //public string FreeCashFlowMargin { get; set; }
        //public string EBITDA { get; set; }
        //public string EBIT { get; set; }
        //public string ConsolidatedIncome { get; set; }
        //public string EarningsBeforeTaxMargin { get; set; }
        //public string NetProfitMargin { get; set; }
    }
}
