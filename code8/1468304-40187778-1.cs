    var result_1 = grid
        // Create quadratic groups by calculating the combined index of the row+column with the quadratic group factor.
        .SelectMany(r =>
            r.GroupBy(c =>
                (int)Math.Floor((double)grid.IndexOf(r) / (double)n)
                    + "_" +
                (int)Math.Floor((double)r.IndexOf(c) / (double)n)
            )
        )
        // Combine all same keys together in one group.
        .GroupBy(g => g.Key)
        // Get all results per group.
        .Select(gg => gg.SelectMany(g => g).ToList())
        // ToList() because it's easier to inspect the value of the result while debugging.
        .ToList();
    // Short version:
    var result_2 = grid
        .SelectMany(r =>
            r.GroupBy(c =>
                (int)Math.Floor((double)grid.IndexOf(r) / (double)n) + "_" + (int)Math.Floor((double)r.IndexOf(c) / (double)n)
            )
        )
        .GroupBy(g => g.Key)
        .Select(gg => gg.SelectMany(g => g).ToList())
        .ToList();
