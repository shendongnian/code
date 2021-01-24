    var timeTables = db.TimeTables
            .Where(c=> c.Today == today)
            .Select(c => new
            {
                c.INN,
                StartDay = DateTime.ParseExact(c.StartDay,"d-M-yyyyTH:m:ss", 
                                               CultureInfo.InvariantCulture)
                                   .ToString("yyyy-MM-ddTHH:mm:ss"),
                c.StartPause,
                c.EndPause,
                c.EndDay
            }).AsEnumerable();
