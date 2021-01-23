    var dictionary = value
        .GroupBy(v => v.Grade)
        .ToDictionary(g => g.Key, 
            g => new 
                {
                    g.Select(x => x.Gold).FirstOrDefault(),
                    g.Select(x => x.Green).FirstOrDefault()
                });
