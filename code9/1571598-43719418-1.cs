    public static class ExpressionHelper
    {
        private static readonly MethodInfo LambdaMethod = typeof(Expression)
            .GetMethods()
            .First(x => x.Name == "Lambda" && x.ContainsGenericParameters && x.GetParameters().Length == 2);
        private static MethodInfo GetLambdaFuncBuilder(Type source, Type dest)
        {
            var predicateType = typeof(Func<,>).MakeGenericType(source, dest);
            return LambdaMethod.MakeGenericMethod(predicateType);
        }
        public static PropertyInfo GetPropertyInfo<T>(string name)
            => typeof(T).GetProperties()
            .Single(p => p.Name == name);
        public static ParameterExpression Parameter<T>()
            => Expression.Parameter(typeof(T));
        public static MemberExpression GetPropertyExpression(ParameterExpression obj, PropertyInfo property)
            => Expression.Property(obj, property);
        public static LambdaExpression GetLambda<TSource, TDest>(ParameterExpression obj, Expression arg)
            => GetLambda(typeof(TSource), typeof(TDest), obj, arg);
        public static LambdaExpression GetLambda(Type source, Type dest, ParameterExpression obj, Expression arg)
        {
            var lambdaBuilder = GetLambdaFuncBuilder(source, dest);
            return (LambdaExpression)lambdaBuilder.Invoke(null, new object[] { arg, new[] { obj } });
        }
    }
