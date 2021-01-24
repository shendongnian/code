    var listMRInfo = Enumerable.Range(0, 200)
        .AsParallel()
        .Select(j =>
        {
            // Code here
            return r1;
        })
        .ToList();
