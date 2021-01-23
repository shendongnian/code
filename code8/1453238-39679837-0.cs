    var topResults = simulationResults
        .GroupBy(r => new
        { 
            WinnerId = r.Winner.Id,
            SecondId = r.Second.Id,
            ThirdId = r.Third.Id,
            FourthId = r.Fourth.Id,
        })
        .OrderByDescending(g => g.Count())
        .Select(g => g.First()) // or new { Result = g.First(), Count = g.Count() } if you need the count
        .Take(50)
        .ToList();
