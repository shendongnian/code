                var openData = new List<dynamic>()
                .Select(g => new {
                    dt = string.Format("{0}/{1}", g.Key.Month, g.Key.Year),
                    g.Key.Year,
                    g.Key.Month,
                    actions = g.Value.Where(x => x.Key == ReportType.Open) //Filter it here
                })
                .GroupBy(l => new {
                    l.Month,
                    l.Year
                })
                .Select(s =>
                new
                {
                    s.Key.Month,
                    s.Key.Year,
                    s.Sum(x => x.actions.Sum(sum => sum.Value))
                })
                .OrderByDescending(a => a.Key)
                .ToList();
