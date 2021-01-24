    List<DateTime> fileDate = new List<DateTime>();
    for (int i = 0; i <= countofdifffile; i++)
    {                        
        var dt = DateTime.ParseExact(fileListfordiff[i].Substring(22, 8), 
                                     "yyyyMMdd", CultureInfo.InvariantCulture)
        fileDate.Add(dt);
        fileDate.Add(dt.AddDays(-5)); // Adds 5 days less date.
    }
