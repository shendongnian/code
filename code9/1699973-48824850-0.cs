    var query = result.Journey
      .GroupBy(x => new { x.From, x.To })
      .Select(g => new
      {
        From = g.Key.From,
        To = g.Key.To,
        MCount = g.Count(x => x.Gender == "M"),
        FCount = g.Count(x => x.Gender == "F"),
        CCount = g.Count(x => x.Gender == "C")
      });
