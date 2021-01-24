    public static class ReflectionExtensions
    {
        public static TAttribute GetAttribute<TAttribute, TClass>(this TClass target, Expression<Func<TClass, object>> targetProperty) where TAttribute : Attribute
        {
            var lambda = (LambdaExpression) targetProperty;
            var unaryExpression = (UnaryExpression) lambda.Body;
            string name = ((MemberExpression) unaryExpression.Operand).Member.Name;
            MemberInfo info = typeof(TClass).GetProperty(name);
            return info.GetCustomAttribute<TAttribute>(false);
        }
    }
