    public static IEnumerable<CareTask> GetByReferenceIds(List<string> referenceIds)
    {
        return DBUtils.DBService.Cypher
            .Match("(node:CareTask)")
            .Where("node.ReferenceId IN {referenceIds}")
            .WithParams(new { referenceIds })
            .Return(node => node.As<CareTask>())
            .Results.ToList();
    }
