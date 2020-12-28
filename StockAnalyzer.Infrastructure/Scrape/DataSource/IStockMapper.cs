﻿using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.DataSource
{
    public interface IStockMapper
    {
        Stock Map(StockRawData.Row rawDataRow);
    }
}
