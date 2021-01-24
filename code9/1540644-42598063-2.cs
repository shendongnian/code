    var stats = _statsRepository.FindBy(x => x.Active)
                .GroupBy(x => new { x.LeagueId, x.Date })
                .GroupBy(g => g.Key.LeagueId)
                .Select(gg => new { LeagueId = gg.Key, Stats = gg.OrderByDescending(g => g.Key.Date).First().ToList() })
                .ToList();
