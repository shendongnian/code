    var b = countries
        .GroupBy(c => c.CountryCode)
        .Select(g => new
            {
                CountryName = g.First().Country.CountryName,  // assuming that there is 1 country code per country name
                Total = g.Sum(x => x.BudgetTotal)
            })
        .OrderByDescending(c => c.Total);
