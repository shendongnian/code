    public class ExpressionFlattener 
    {
        public ExpressionFlattener(MethodInfo selectMethod)
        {
            SelectMethod = selectMethod;
        }
        /// <summary>
        /// Flattens the specified expression.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>IEnumerable&lt;Expression&lt;Func&lt;TEntity, System.Object&gt;&gt;&gt;.</returns>
        public IEnumerable<Expression<Func<TEntity, object>>> Flatten<TEntity>(Expression<Func<TEntity, object>> expression) => Flatten(expression, new List<Expression>()).Cast<Expression<Func<TEntity, object>>>();
        /// <summary>
        /// Gets the select method.
        /// </summary>
        /// <value>The select method.</value>
        private MethodInfo SelectMethod { get; }
        /// <summary>
        /// Flattens the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="expressions">The expressions.</param>
        /// <returns>List&lt;Expression&gt;.</returns>
        /// <exception cref="ArgumentException">Invalid expression specified, the specified expression is of an unhandled node type.</exception>
        private List<Expression> Flatten(Expression expression, List<Expression> expressions)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Call: return FlattenMethodCall(expression as MethodCallExpression, expressions);
                case ExpressionType.Lambda: return FlattenLambda(expression as LambdaExpression, expressions);
                case ExpressionType.MemberAccess: expressions.Add(expression); return expressions;
                case ExpressionType.New: return FlattenNew(expression as NewExpression, expressions);
                default: throw new ArgumentException("Invalid expression specified, the specified expression is of an unhandled node type.");
            }
        }
        /// <summary>
        /// Flattens the lambda expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="expressions">The expressions.</param>
        /// <returns>List&lt;Expression&lt;Func&lt;TEntity, System.Object&gt;&gt;&gt;.</returns>
        /// <exception cref="ArgumentException">Invalid expression specified, the specified expression has a body with an unhandled node type.</exception>
        private List<Expression> FlattenLambda(LambdaExpression expression, List<Expression> expressions)
        {
            //Flatten the body expression.
            List<Expression> innerExpressions = Flatten(expression.Body, new List<Expression>());
            //We should never be creating a lambda expression which returns more than one property as we should
            //have flattened everything out with the call to the above. So it should be safe? to assume we're
            //inputting the same parameter type but just getting out an object.
            Type delegateType = typeof(Func<,>).MakeGenericType(expression.Parameters[0].Type, typeof(object));
            //Rebuild the lambda expression for each expression returned.
            foreach (Expression innerExpression in innerExpressions)
                expressions.Add(Expression.Lambda(delegateType, innerExpression, expression.Parameters[0]));
            return expressions;
        }
        /// <summary>
        /// Flattens the method call expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="lambdaExpression">The lambda expression.</param>
        /// <returns>List&lt;Expression&lt;Func&lt;TEntity, System.Object&gt;&gt;&gt;.</returns>
        /// <exception cref="ArgumentException">Invalid method call expression specified, the method call specified expression is to an unhandled method.</exception>
        private List<Expression> FlattenMethodCall(MethodCallExpression expression, List<Expression> expressions)
        {
            switch (expression.Method.Name)
            {
                case "Select":
                    {
                        //The second argument will be the right side of the select statement e.g. property.Select(argument0 => argument1);
                        List<Expression> innerExpressions = Flatten(expression.Arguments[1], new List<Expression>());
                        //Create the select method.
                        //The first argument should always be the object we're passing in, so it will be the same.
                        //The second argument has been normailised into an object, e.g. from a single property or an anonyamous object containing multiple properties.
                        MethodInfo method = SelectMethod.MakeGenericMethod(expression.Method.GetGenericArguments().First(), typeof(object));
                        //Rebuild the select expression for each expression returned.
                        foreach (Expression innerExpression in innerExpressions)
                            expressions.Add(Expression.Call(method, expression.Arguments[0], innerExpression));
                        return expressions;
                    }
                default: throw new ArgumentException("Invalid method call expression specified, the method call expression is to an unknown method.");
            }
        }
        /// <summary>
        /// Flattens the new expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="expressions">The expressions.</param>
        /// <returns>List&lt;Expression&gt;.</returns>
        private List<Expression> FlattenNew(NewExpression expression, List<Expression> expressions)
        {
            //TODO: Make sure we're an anonyamous type.
            foreach (Expression argument in expression.Arguments)
                Flatten(argument, expressions);
            return expressions;
        }
    }
