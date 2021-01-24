    class DictionaryReplaceVisitor : ExpressionVisitor
    {
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if(node.Object != null && node.Object.Type == typeof(Dictionary<int, string>) && node.Method.Name == "get_Item")
            {
                Expression exp = Expression.Constant(""); //Default order key
                // Compile the tahrget of the index and execute it to get the value
                // If you know there is a single dictionary you could replace this with a class property intead and set it from the Visit call site, 
                // but this is the more general appraoch
                var dict = Expression.Lambda<Func<Dictionary<int, string>>>(node.Object).Compile()();
                foreach (var kv in dict)
                {
                    exp = Expression.Condition(
                        Expression.Equal(
                            node.Arguments.Single(),
                            Expression.Constant(kv.Key)
                        ),
                        Expression.Constant(kv.Value),
                        exp
                    );
                }
                return exp;
            }
            return base.VisitMethodCall(node);
        }
    }
