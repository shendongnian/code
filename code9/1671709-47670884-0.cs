     public TP SetTValue<T, TP>(Expression<Func<T, TP>> action, TP value) where T : class
        {
            var member = action.Body is UnaryExpression ? ((MemberExpression)((UnaryExpression)action.Body).Operand) : (action.Body is MethodCallExpression ? ((MemberExpression)((MethodCallExpression)action.Body).Object) : (MemberExpression)action.Body);
            var key = member?.Member.Name; // the propertyName. use it like you want 
            return (TP)(this[key] = value);
        }
