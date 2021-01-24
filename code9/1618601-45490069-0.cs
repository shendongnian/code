    using(var SMSEntities = new SMSEntities()
    {
        // Your first query
        var messages = entities.SMSMessage
            .Where(item => item.TimeSent == null && item.Deleted == 0 && item.StatusID == 0)
            .ToList();
        // To simulate whatever you're doing in SSMS here.
        LongRunningMethod();
        // At this point, even when you re-query, you will not be getting the updated values.
        messages = entities.SMSMessage
            .Where(item => item.TimeSent == null && item.Deleted == 0 && item.StatusID == 0)
            .ToList();
        
        // To get updated values, do this.
        SMSEntities.Entry(messages).Reload();
        // Messages here will be updated with what you did in SSMS.
        messages = entities.SMSMessage
            .Where(item => item.TimeSent == null && item.Deleted == 0 && item.StatusID == 0)
            .ToList();
    }
