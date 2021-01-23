    var myItems = items.Select(item => new
    {
        X = item.A,
        Y = item.B,
        Z = item.C,
    })
    .Select(item => new
    {
        X = item.A,
        Z = item.C,
    });
