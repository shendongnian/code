    class CustomExpressionVisitor : DefaultExpressionVisitor
    {
        // Override method to mutate the query 
    }
    class TestInterceptor : IDbCommandTreeInterceptor
    {
        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.Result.DataSpace == DataSpace.CSpace)
            {
                // We only process query command trees 
                // (there can be others such as insert, update or delete
                var queryCommand = interceptionContext.Result as DbQueryCommandTree;
                if (queryCommand != null)
                {
                    // A bit of logging to see the original tree
                    Console.WriteLine(queryCommand.DataSpace);
                    Console.WriteLine(queryCommand);
                    // We call the accept method on the command expression with our new visitor. 
                    // This method will return our new command expression with the changes the 
                    // visitor has made to it
                    var newQuery = queryCommand.Query.Accept(new CustomExpressionVisitor());
                    // We create a new command with our new command expression and tell 
                    // EF to use it as the result of the query
                    interceptionContext.Result = new DbQueryCommandTree
                    (
                         queryCommand.MetadataWorkspace,
                         queryCommand.DataSpace,
                         newQuery
                     );
                    // A bit of logging to see the new command tree
                    Console.WriteLine(interceptionContext.Result);
                }
            }
        }
    }
    // In code before using any EF context.
    // Interceptors are registered globally.
    DbInterception.Add(new TestInterceptor());
