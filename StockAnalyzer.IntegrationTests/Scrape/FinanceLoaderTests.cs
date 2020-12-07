﻿using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape;
using StockAnalyzer.Infrastructure.Scrape.Config;
using StockAnalyzer.Infrastructure.Serialize;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace StockAnalyzer.IntegrationTests.Scrape
{
    public class FinanceLoaderTests
    {

        [Fact]
        public void IncomesLoadProperly()
        {
            FinanceLoader<Income> loader = new FinanceLoader<Income>();
            ScrapedData scrapedData = new ScrapedData
            {
                Periods = new List<string>()
            };
            scrapedData.Periods.AddRange(new List<string> { "2000", "2001", "2002" });
            scrapedData.Rows = new List<ScrapedData.Row>
            {
                new ScrapedData.Row() { Description = "desc1", Label = "InterestIncome", Vals = new List<string>() { "100", "200", "300" } },
                new ScrapedData.Row() { Description = "desc2", Label = "EBITDA", Vals = new List<string>() { "123", "456", "789" } },
                new ScrapedData.Row() { Description = "desc3", Label = "DiscontinuedProfit", Vals = new List<string>() { "111", "222", "333" } }
            };
            List<Income> incomes=loader.Load(scrapedData.Rows);
            Assert.Equal(100, incomes[0].InterestIncome);
            Assert.Equal(200, incomes[1].InterestIncome);
            Assert.Equal(300, incomes[2].InterestIncome);

            Assert.Equal(123, incomes[0].EBITDA);
            Assert.Equal(456, incomes[1].EBITDA);
            Assert.Equal(789, incomes[2].EBITDA);

            Assert.Equal(111, incomes[0].DiscontinuedProfit);
            Assert.Equal(222, incomes[1].DiscontinuedProfit);
            Assert.Equal(333, incomes[2].DiscontinuedProfit);

        }

    }
}
