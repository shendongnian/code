    public async Task Execute(string[] clauses)
    {
        var taskList = clauses.Select(ExecuteClause);
        return Task.WhenAll(taskList);
    }
