    var maxQuery = 50000;
    var cpt = maxQuery;
    var countHits = (int)client.Search<Model>(s => s.Index("MyIndex").Type("MyType")
        .Query(q => q.QueryString(qs => qs.Query(query)))).Total;
    for (var i = 0; i < ((countHits - maxQuery) / maxQuery); i++)
    {
        var res =
            client.Search<Model>(s => s.Index("MyIndex").Type("MyType").From(cpt).Size(maxQuery)
                .Query(q => q.QueryString(qs => qs.Query(query))));
        cpt += maxQuery;
        results.AddRange(res.Documents.Select(x => new EntrepriseSireneDL(x)));
    }
    var lastScrollSize = countHits - cpt;
    var r =
        client.Search<Model>(s => s.Index("MyIndex").Type("MyType").From(cpt).Size(lastScrollSize)
            .Query(q => q.QueryString(qs => qs.Query(query))));
    results.AddRange(r.Documents.Select(x => new ModelDL(x)));
    return results;
