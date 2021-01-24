    var searchRequest = new SearchRequest<Project>
    {
        Aggregations = 
            new TermsAggregation("project_tags") { Field = Nest.Infer.Field<Project>(p => p.Tags) } &&
            new TermsAggregation("project_branches") { Field = Nest.Infer.Field<Project>(p => p.Branches) } &&
            new NestedAggregation("commits") 
            {
                Path = Nest.Infer.Field<Project>(p => p.Commits),
                Aggregations = 
                    new StatsAggregation("commit_size_stats", Nest.Infer.Field<Project>(p => p.Commits.First().SizeInBytes))
            }
    };
    var searchResponse = client.Search<Project>(searchRequest);
