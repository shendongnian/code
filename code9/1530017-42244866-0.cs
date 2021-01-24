    from messages in  message
    where (messages .ObservationDateTime < sqm.To) 
               && (messages .ObservationDateTime > sqm.From))
    group orders by EntityFunctions.TruncateTime(m.ObservationDateTime) 
               into dateMessages
    select new StatsticsVm()
        {
            Label = dateMessages.key.Day + "/" + dateMessages.key.Month + "/" + dateMessages.key.Year,
            MessagesCount = dateMessages.Count()
        };
