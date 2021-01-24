        public static class ExtensionToExpression
        {
            public static Expression<Func<TTo, bool>> Converter<TFrom, TTo>(this Expression<Func<TFrom, bool>> expression, TTo type) where TTo : TFrom
            {
                 // here we get the expression parameter the x from (x) => ....
                 var parameterName = expression.Parameters.First().Name;
                 // create the new parameter from the correct type
                 ParameterExpression parameter = Expression.Parameter(typeof(TTo), parameterName);
                 // asigne to allow the visit from or visitor
                 Expression body = new ConvertVisitor(parameter).Visit(expression.Body);
                 // recreate the expression
                 return Expression.Lambda<Func<TTo, bool>>(body, parameter);
            }
        }
