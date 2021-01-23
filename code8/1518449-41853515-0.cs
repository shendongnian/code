        var dt = new DateTime(2017, 01, 25, 7, 31, 0);
        DateTime univDateTime = dt.ToUniversalTime();
        string nzTimeZoneKey = "Pacific Standard Time (Mexico)";
        TimeZoneInfo nzTimeZone = TimeZoneInfo.FindSystemTimeZoneById(nzTimeZoneKey);
        DateTime nzDateTime = TimeZoneInfo.ConvertTime(univDateTime, nzTimeZone);
