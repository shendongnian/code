    using (var context = new DbEntities())
    {        
        // get date
        var latestDate = context.Logs.Max(o => o.RowCreateDate);
        if(latestDate!=null)
        {
            lastDate = new DateTime(latestDate.Value.Year, latestDate.Value.Month, latestDate.Value.Day,00,00,00);
            logs = context.Logs
                .OrderBy(o => o.RowCreateDate)
                .AsEnumerable()
                .TakeWhile(o => o.RowCreateDate >= lastDate);
        }
    }
