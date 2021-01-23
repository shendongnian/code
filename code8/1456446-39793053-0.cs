    var articleIds = new[] { 1, 2, 3, 4 };
    client.Search<PublishedArticle>(s => s
        .Query(q => q
            .Bool(b => b
                .MustNot(mn => mn
                    .Terms(t => t
                        .Field(f => f.AssignedArticleList.FirstOrDefault().AssignedArticleId)
                        .Terms(articleIds)
                    )
                )
            )
        )
    );
