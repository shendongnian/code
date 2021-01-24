    public static async bool QueriesWouldContain<T>(IEnumerable<T> storables, List<string> queryStrings)
        where T : class, IStorable
    {
        foreach (var querystring in queryStrings)
        {
            var expressionSerializer = new ExpressionSerializer(new JsonSerializer());
            var queryStatement = expressionSerializer.DeserializeText(querystring);
            var expression = queryStatement.ToExpressionNode().ToExpression();
            if (!(expression is LambdaExpression lambdaExpression))
                continue; // TODO: or throw
            var d = lambdaExpression.Compile();
            foreach (var storable in storables)
            {
                if (isOfTypeMatchingQuery(storable, d))
                {
                    var result = (bool)d.Invoke(storable);
                    if (result == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
