﻿using StockAnalyzer.Core.StatementAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape
{
    public interface IScrapedLoader<T> where T: Finance
    {
        List<T> Load(List<ScrapedData.Row> dataRows);
    }
}