            var lowestKey = result.Min(x => x.Month);
            var highestKey = result.Max(x => x.Month);       
            query = query.Union(
                Enumerable.Range(lowestKey, highestKey - lowestKey)
                .Where(e => !result.Any(r => r.Month == e))
                .Select(s => new { Month = s, Count = 0 })
                ).OrderBy(o => o.Month).ToList();
