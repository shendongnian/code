    var StateList = from q in query
                     group q by new
                     {
                          q.Lead.State
                     } into g
                     select new AverageLeadSalesPriceItem
                     {
                          StateCode = g.Key.State,
                          StateAverage = g.Average( a=>a.Amount )
                      };
