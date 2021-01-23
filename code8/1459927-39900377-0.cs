    var counts = context
        .Category
        .GroupBy(t => t.IsActive ?? false).ToDictionary(
            g => g.Key
        ,   g => g.Count()
        );
    var res = new {
        Active = counts.ContainsKey(true) ? counts[true] : 0
    ,   Inactive = counts.ContainsKey(false) ? counts[false] : 0
    };
