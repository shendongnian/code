    Dictionary<string, int> openCounts = new Dictionary<string, int>();
    Dictionary<string, int> sentCounts = new Dictionary<string, int>();
    foreach (var kvp in rawData)
    {
        //var dt = string.Format("{0}-{1}", kvp.Key.ToString("MMMM"), kvp.Key.Year);
        var dt = kvp.Key.ToString("MMMM-yyyy");   //simpler alternative, "MMMM" gives full month name
        foreach (var val in kvp.Value)
        {
            if (val.Key == ReportType.Open)
            {
                if (openCounts.ContainsKey(dt))
                    openCounts[dt] += val.Value;
                else
                    openCounts.Add(dt, val.Value);
            }
            else
            {
                if (sentCounts.ContainsKey(dt))
                    sentCounts[dt] += val.Value;
                else
                    sentCounts.Add(dt, val.Value);
            }
        }
    }
