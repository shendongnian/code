    logDB.PELoggers
        .Where(c => (c.SubscriberCode == SubscriberCode))
        .OrderByField(sortBy, ascendingOrder)
        .Select(c => new LoggerModel()
            {
                DateTime = c.DateTime.Value,
                Event = c.Event.Substring(0, 1).ToUpper()
                        + c.Event.Substring(1)                       
            })
