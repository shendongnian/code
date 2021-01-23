            var newVariable = from item in dealerTFNDatesTable
                       group item by new
                       {
                           item.Date,
                           item.AffiliateID,
                       }
                       into g
                       select new
                       {
                           Date = g.Key.Date,
                           Id = g.Key.AffiliateID,
                           Total = g.Sum(a => a.TotalCalls)
                       };
