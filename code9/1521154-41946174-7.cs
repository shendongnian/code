    var ids = new[] {
        "23f2157f-eb21-400d-b3a1-a61cf1451262",
        "23f2157f-eb21-400d-b3a1-a61cf1451263",
        "23f2157f-eb21-400d-b3a1-a61cf1451264"
    };
    var searchResponse = client.Search<Invoice>(s => s
        .AllIndices()
        .AllTypes()
        .Query(q => q
            .Terms(m => m
                .Field(f => f.LineItems.First().ListItems.First().ListItemID)
                .Terms(ids)
            )
        )
    );
