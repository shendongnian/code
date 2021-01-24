    foreach(var log in commonlog)
    {
        TimeSpan sum;
        groupedLogs.TryGetValue(log.Break, out sum);
        if(sum == TimeSpan.Parse(log.Length))
        {
            // do something
        }
    }
