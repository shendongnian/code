    var results = words.Split(' ')
                       .SelectMany(w => Enumerable.Range(3, Math.Max(0, w.Length - 2)).Select(n => w.Substring(w.Length - n, n)))
                       .GroupBy(pw => pw)
                       .Select(pwg => new { Common = pwg.Key, Count = pwg.Count() })
                       .OrderByDescending(cc => cc.Count)
                       .ThenByDescending(cc => cc.Common.Length)
                       .Take(1);
