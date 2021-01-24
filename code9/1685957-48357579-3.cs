    public abstract class BlackBoxObjectMapper : IObjectMapper
    {
        private static readonly MethodInfo MapMethod = typeof(BlackBoxObjectMapper).GetTypeInfo().GetDeclaredMethod("Map");
        public abstract bool IsMatch(TypePair context);
        public abstract object Map(object source, Type sourceType, object destination, Type destinationType, ResolutionContext context);
        public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap,
            PropertyMap propertyMap, Expression sourceExpression, Expression destExpression,
            Expression contextExpression) =>
            Expression.Call(
                Expression.Constant(this),
                MapMethod,
                sourceExpression,
                Expression.Constant(sourceExpression.Type),
                destExpression,
                Expression.Constant(destExpression.Type),
                contextExpression);
    }
