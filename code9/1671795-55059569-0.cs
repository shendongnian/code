    public static EntityTypeBuilder HasQueryFilter<T>(this EntityTypeBuilder entityTypeBuilder, Expression<Func<T, bool>> filterExpression)
        {
            var param = Expression.Parameter(entityTypeBuilder.Metadata.ClrType);
            var body = ReplacingExpressionVisitor.Replace(filterExpression.Parameters.Single(), param, filterExpression.Body);
            var lambdaExp = Expression.Lambda(body, param);
            return entityTypeBuilder.HasQueryFilter(lambdaExp);
        }
