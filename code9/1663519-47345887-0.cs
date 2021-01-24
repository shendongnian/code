    var dealerResults = 
                   (from r in _results.GroupBy(x => new { x.DealerName, x.DealerId })
                   join llc in linkedLeadCores on r.Key.DealerId equals llc.DealerId into g
                   select new MarketingReportResults()
                   {
                      DealerId = r.Key.DealerId,
                      DealerName = r.Key.DealerName,
                      LinkedTotal = g.Count(),
                      LeadsTotal = r.Count(),
                      SalesTotal = r.Count(y => y.IsSold),
                      Percent = (decimal)(r.Count() * 100) / count,
                      ActiveTotal = r.Count(y => y.IsActive),
                  }).ToList();
