    logDB.PELoggers
        .Where(c => (c.SubscriberCode == SubscriberCode))
        .OrderByField(sortBy, ascendingOrder)
        .AsEnumerable()
        .Select(c => new LoggerModel()
            {
                DateTime = c.DateTime.Value,
                Event = c.Event.FirstUpper()                       
            })
