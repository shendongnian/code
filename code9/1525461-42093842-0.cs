    var sTab = new ConcurrentBag<int>(Enumerable.Range(min, max));
    Parallel.ForEach(sTab, (i) =>
                {
                    string Convert = new XMLConverter().XMLConverterSQL(i, "EN");
                    lock (results)
                    {
                        results.Add(Convert);
                    }
                });
