    var newData = data.Select(a => new IHSData
    {
        PriceSymbol = Convert.ToString(a.PriceId),
        PeriodData = a.ObservationVector.Select(x => Convert.ToDateTime(x.Period)).ToList(),
        StatusID = a.ObservationVector.Select(x => Convert.ToInt32(x.StatusId)).ToList(),
        Price = a.ObservationVector.Select(x => Convert.ToDouble(x.price)).ToList(),
    });
