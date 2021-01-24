    IEnumerable<Test> Group(this IEnumerable<MyData> data)
    {
        var pairs = data
            .SelectMany(d => d.TestList
                 .Select(t => new {
                     Region = d.Region,
                     TestId: t.TestId
                 })
            );
        // now group by testId
        var groups = pairs.GroupBy(pair => pair.TestId);
        // now convert each group to your Test class
        var result = groups.Select(group => new Test
            {
                TestId = pair.Key,
                VariantsRanks = group.Select((p, i) =>
                   new VariantsRank { Name = p.Region, Rank = i }).ToList()
            }
        );
        return result;
    }
