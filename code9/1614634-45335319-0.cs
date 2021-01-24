    var input = new List<FullMessage>();
    var result = input.GroupBy(m => new { m.MessageNumber, m.Total })
        .Where(g => g.Count() == g.Key.Total)
        .Select(g => new FullMessage
        {
            MessageNumber = g.Key.MessageNumber,
            Message = g.OrderBy(i => i.PartNumber).Aggregate("", (c, n) => c + n)
        });
