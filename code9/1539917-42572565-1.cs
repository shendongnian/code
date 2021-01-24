    var result = ctx.Database.SqlQuery<GraphUpdateResult>SqlStatement.ToString()).ToList();
    foreach (var graphResult in result)
    {
       Console.WriteLine(graphResult.Id);
       Console.WriteLine(graphResult.Temp);
    }
