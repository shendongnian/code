    for (int i = 0; i < values.Length; i++)
    {
        AgeWeightedHistorical ag = new AgeWeightedHistorical();
        ag.ExposureDate = datetime[i];
        ag.ProfolioPrices = values[i];
        ag.LastPeriods = values.Length - Data.Count;
        Data.Add(ag);
    }
