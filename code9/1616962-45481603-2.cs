    var result = input
        .GroupBy(raw => new
        {
            raw.Key,
            IsSeparateGroup = NeedsSeparateGroup(raw.Key, raw.Value)
        }, (k, vs) => new
        {
            k.Key,
            k.IsSeparateGroup,
            Values = vs.Select(r => r.Value).ToList()
        });
