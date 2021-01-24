            SearchRequest request = new SearchRequest("things", "child")
            {
                From = 0,
                Size = 10,
                Query = new HasParentQuery
                {
                    Type = "parent",
                    InnerHits = new InnerHits(),
                    Query = new MatchAllQuery()
                }
            };
            var response = _client.Search<Child>(request);
