    private static LambdaExpression ConvertFilterExpression<TInterface>(
                                Expression<Func<TInterface, bool>> filterExpression,
                                Type entityType)
                    {
                        var newParam = Expression.Parameter(entityType);
                        var newBody = ReplacingExpressionVisitor.Replace(filterExpression.Parameters.Single(), newParam, filterExpression.Body);
            
                        return Expression.Lambda(newBody, newParam);
                    }
