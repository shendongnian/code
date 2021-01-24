    public static IEnumerable<CareTask> GetByReferenceIds(List<string> ids)
    {
        return DBUtils.DBService.Cypher
            .Match("(node:Task)")
            .Where("node.Id IN {ids}")
            .WithParam("ids", ids)
            .Return(node => node.As<Task>())
            .Results.ToList();
    }
