            var query = from stocks in context.Stocks 
                        join products in context.ProductTransactions ON stocks.StockId equals products.StockId
                        where stocks.UserCompanyId = userCompanyId
                        group stocks by new
                        {
                            stocks.StockId,
                            stocks.StockName
                        } into gcs
                        select new
                        {
                            StockId = gcs.Key.StockId,
                            StockName = gcs.Key.StockName,
                            ProductCounts = gcs.Count()
                        };
