    IEnumerable<FullMessage> combinedMessages = messages.GroupBy(m => m.MessageNumber)
        .Select(g => g.OrderBy(m => m.PartNumber)
        .Aggregate(new FullMessage() { MessageNumber = g.Key }, (r, m) =>
        {
            r.Message += m.Message;
            r.Total += m.Total;
            return r;
        }));
