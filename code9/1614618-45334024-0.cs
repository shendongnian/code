    dtnbars.Add( new DTNBars {
        Date_Time = csvr.GetField<DateTime>(0),
        Open = csvr.GetField<double>(1),
        High = csvr.GetField<double>(2),
        Close = csvr.GetField<double>(4),
        Ticker = symbol });
