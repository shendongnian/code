    from t in db.SomeTable
    orderby t.Time
    group t by new { t.Time.Date, t.Time.Hour } into g
    select new
    {
        Time = g.Min(t => t.Time),
        Result1 = g.Average(t => t.Result1),
        Result2 = g.Average(t => t.Result2),
    }
