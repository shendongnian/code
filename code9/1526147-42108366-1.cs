        Dictionary<DateTime, double[]> preResult = masterlist.SelectMany(s => s).GroupBy(k => k.Key)
            .ToDictionary(k => k.Key, v => v.Select(s => s.Value).ToArray());
       var result = preResult.Select(s =>
        {
            var res = new List<object>(); 
            res.Add(s.Key);
            res.AddRange(s.Value.Cast<object>());
            return res.ToArray(); 
        }).ToArray();
