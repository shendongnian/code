    var consolidatedChildren =
    from c in children
    group c by new
    {
        c.Col1,
        c.Col2,
        c.Col3,
        c.Col4
    } into gcs
    select new ConsolidatedChild()
    {
        Col1= gcs.Key.Col1,
        Col2= gcs.Key.Col2,
        Col3= gcs.Key.Col3,
        Col4= gcs.Key.Col4,
        Col5= gcs.ToList(),
    };
