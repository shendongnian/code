    var monthList = flyers.Where(i => i.FlyerDate.Year >= 2013)
        .GroupBy(i => new { i.FlyerDate.Year, i.FlyerDate.Month })
        .Select(g => new { 
            Year  = g.Key.Year,
            Month = g.Key.Month, 
            FullDate = DateTimeFormatInfo.CurrentInfo.GetMonthName(g.Key.Month) + " " + g.Key.Year
        });
