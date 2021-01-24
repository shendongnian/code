    private static BlockSyntax GetMethodBody(BaseApiMethodInfo methodInfo, string controllerName)
    {
        var statements = new List<StatementSyntax>();
        ...
        statements.Add(ParseStatement($"var handle = Client.ExecuteAsync(request, r => taskCompletion.SetResult(r));"));
        statements.Add(ParseStatement($"var response = await taskCompletion.Task;"));
        statements.Add(ParseStatement($"return JsonConvert.DeserializeObject<{TypesHelper.GetTypeName(methodInfo.ReturnedType)}>(response.Content);"));
    
        return Block(statements);
    }
