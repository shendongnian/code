    var startDate = DateTime.Now;
    var endDate = DateTime.Now.AddDays(n);
    if (startDate.Year == endDate.Year)
    {
        // Simple case, just compare months and days.
        GetAll().Where(
            x => x.BirthDate.Value.Month >= startDate.Month &&
                x.BirthDate.Value.Day >= startDate.Day &&
                x.BirthDate.Value.Month <= endDate.Month &&
                x.BirthDate.Value.Day <= endDate.Day);
    }
    else
    {
        // Range spanning two distinct years, so matching dates
        // are either lower months and days than endDate, OR
        // greater months and days than startDate. (Cannot have both.)
        GetAll().Where(
            x => x.BirthDate.Value.Month >= startDate.Month &&
                x.BirthDate.Value.Day >= startDate.Day ||
                x.BirthDate.Value.Month <= endDate.Month &&
                x.BirthDate.Value.Day <= endDate.Day);
    }
