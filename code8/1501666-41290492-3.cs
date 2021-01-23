        public static IEnumerable<PriceRecord> ReduceOverlaps(IEnumerable<PriceRecord> source)
        {
            // Get a list of all edges of date ranges
            // edit, added OrderBy (!)
            var edges = source.SelectMany(record => new[] { record.StartDate, record.EndDate }).OrderBy(d => d).ToArray();
            // iterate over pairs of edges (i and i-1)
            for (int i = 1; i < edges.Length; i++)
            {
                // select min price for range i-1, i
                var price = source.Where(r => r.StartDate <= edges[i - 1] && r.EndDate >= edges[i]).Select(r => r.Price).Min();
                // return a new record from i-1, i with price
                yield return new PriceRecord() { StartDate = edges[i - 1], EndDate = edges[i], Price = price };
            }
        }
