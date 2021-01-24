    var recordsByWeek = Enumerable.Range(0, 4).ToDictionary(i => i + 1, i =>
    {
        var start = DateTime.Today.AddDays(7 * i);
        var end = start.AddDays(7);
        return records.Where(r => start <= r.Date && r.Date < end).ToList();
    });
