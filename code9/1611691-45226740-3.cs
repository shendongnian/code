    var searchRequest = new SearchRequest<Project>
    {
        Aggregations = new AggregationDictionary
        {
            { "project_tags", new TermsAggregation("project_tags") { Field = Nest.Infer.Field<Project>(p => p.Tags) } },
            { "project_branches", new TermsAggregation("project_branches") { Field = Nest.Infer.Field<Project>(p => p.Branches) } },
            { "commits", new NestedAggregation("commits") 
                {
                    Path = Nest.Infer.Field<Project>(p => p.Commits),
                    Aggregations = new AggregationDictionary
                    {
                        { "commit_size_stats", new StatsAggregation("commit_size_stats", Nest.Infer.Field<Project>(p => p.Commits.First().SizeInBytes)) },
                    }
                }
            }
        }
    };
    var searchResponse = client.Search<Project>(searchRequest);
