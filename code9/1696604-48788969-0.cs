            PercolatedQuery documentQuery = new PercolatedQuery
            {
                Id = "PercolatedQuery",
                Query = new MatchQuery
                {
                    Field = Infer.Field<PercolatedQuery>(entry => entry.Body),
                    Query = "healthcare biggest"
                }
            };
            Client.Index(documentQuery,
               d => d.Index("mytestIndex").Refresh(Refresh.WaitFor));
            PercolatedQuery document1 = new PercolatedQuery { Body = "healthcare biggest winner" };
            Client.Search<PercolatedQuery>(s => s
                .Query(q => q
                    .Percolate(p => p
                        .Field(f => f.Query)
                        .Document(document1)
                    )
                )
                );
