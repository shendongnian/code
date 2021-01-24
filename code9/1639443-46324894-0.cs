        public static Expression<Func<TEntity, bool>> Predicate<TEntity>(object value, string name, ExpressionType operation = ExpressionType.Equal)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            
            // Getting the names of the properties
            var properties = name.Split(".");
            //Getting the propety
            var property = Expression.Property(parameter, properties[0]);
            property = properties.Skip(1).Aggregate(property, Expression.Property);
            //Create a Constant Expression for the property value setting its type to be of type of the desired property
            var propertyValue = Expression.Constant(value, property.Type);
            //Making the comparison
            var comparison = Expression.MakeBinary(operation, property, propertyValue);
            //Creating the expression lambdaExpression.
            var expression = Expression.Lambda<Func<TEntity, bool>>(comparison, parameter);
            
            //Converting the lambdaExpression to required Expression Type
            return expression.Cast<TEntity, bool>();
        }
        
        public static Expression<Func<TModel, TResult>> Cast<TModel, TResult>(this LambdaExpression expression)
        {
            return Expression.Lambda<Func<TModel, TResult>>(Expression.Convert(expression.Body, typeof(TResult)), expression.Parameters);
        }
        public static Expression<Func<TEntity, object>> GetExpression<TEntity>(this string order)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var properties = order.Split(".");
            var property = properties.Skip(1).Aggregate(Expression.Property(parameter, properties[0]), Expression.Property);
            var expression = Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(TEntity), property.Type), property, parameter);
            return expression.Cast<TEntity, object>();
        }
