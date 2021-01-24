    private IEnumerable<StatsticsVm> GetStatsticsPerDay(StatsticsQueryModel sqm)
    {
        var messages = GetMessagesByDateAndIU(sqm);
        var dateRange = Enumerable.Range(0, 1 + sqm.To.Subtract(sqm.From).Days)
                                  .Select(offset => sqm.From.AddDays(offset));
        IEnumerable<StatsticsVm> messagesCountPerDay =
            from date in dateRange
            join message in messages on date
            equals message.ObservationDateTime into g
            select new StatsticsVm()
            {
                Label = date.Day + "/" + date.Month + "/" + date.Year,
                MessagesCount = g.Count()
            };
        return messagesCountPerDay;
    }
