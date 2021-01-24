    var newData = data
        .SelectMany(a => a.ObservationVector.Select(v =>
            new IHSData
            {
                PriceSymbol = Convert.ToString(a.PriceId),  // parent PriceId
                PeriodData = Convert.ToDateTime(v.Period),
                StatusID = Convert.ToInt32(v.StatusId),
                Price = Convert.ToDouble(v.price),
            }))
       .ToList();
