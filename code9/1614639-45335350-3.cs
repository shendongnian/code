    IEnumerable<FullMessage> combinedMessages = messages.GroupBy(m => m.MessageNumber)
        .Select(g => g.OrderBy(m => m.PartNumber)
        .Aggregate(new FullMessage() { MessageNumber = g.Key }, (r, m) =>
        {
            r.Message += m.Message;
            //Not sure if counting up is required in your code
            //so the following line is optional
            r.Total += m.Total;
            return r;
        }));
