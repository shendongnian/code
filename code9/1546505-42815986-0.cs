    var StateList = from q in query
                 group q by q.Lead.State into g
                 select new AverageLeadSalesPriceItem
                 {
                      StateCode = g.Key.State,
                      StateAverage = g.Average(gq=>gq.Amount),
                 };
