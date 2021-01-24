    public class ContainerDestinationMapper : BaseContainerMapper, IObjectMapperInfo
    {
        readonly Func<Type, Expression> createContainer;
        public ContainerDestinationMapper(Type GenericContainerTypeDefinition, String ContainerPropertyName, Func<Type, Expression> createContainer)
            : base(GenericContainerTypeDefinition, ContainerPropertyName)
        {
            this.createContainer = createContainer;
        }
        public bool IsMatch(TypePair context) => ContainerDef(context.DestinationType) != null;
        public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap,
            PropertyMap propertyMap, Expression sourceExpression, Expression destExpression,
            Expression contextExpression)
        {
            var dparam = DigParameter(destExpression);
            var dVal = Expression.Property(dparam, dparam.Type.GetTypeInfo().GetDeclaredProperty("Value"));
            var cdt = ContainerDef(destExpression.Type);
            var tp = new TypePair(sourceExpression.Type, cdt);
            var ret = Expression.Block
                        (
                            // make destination not null
                            Expression.IfThen
                            (
                                Expression.Equal(dparam, Expression.Constant(null)),
                                Expression.Assign(dparam, createContainer(cdt))
                            ),
                            // Assign to the destination
                            Expression.Assign
                            (
                                dVal,
                                ExpressionBuilder.MapExpression // what you get if you map source to dest.Value
                                (
                                    configurationProvider,
                                    profileMap,
                                    tp,
                                    sourceExpression,
                                    contextExpression,
                                    null,
                                    dVal
                                )
                            ),
                            destExpression // But we need to return the destination type!
                        );
            return ret;
        }
        public TypePair GetAssociatedTypes(TypePair initialTypes)
        {
            return new TypePair(initialTypes.SourceType, ContainerDef(initialTypes.DestinationType));
        }
    }
    public class ContainerSourceMapper : BaseContainerMapper, IObjectMapperInfo
    {
        public ContainerSourceMapper(Type GenericContainerTypeDefinition, String ContainerPropertyName)
            : base(GenericContainerTypeDefinition, ContainerPropertyName) { }
        public bool IsMatch(TypePair context) => ContainerDef(context.SourceType) != null;
        public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap,
            PropertyMap propertyMap, Expression sourceExpression, Expression destExpression,
            Expression contextExpression) =>
                ExpressionBuilder.MapExpression(configurationProvider, profileMap,
                    new TypePair(ContainerDef(sourceExpression.Type), destExpression.Type),
                    Expression.Property(sourceExpression, sourceExpression.Type.GetTypeInfo().GetDeclaredProperty(containerPropertyName)),
                    contextExpression,
                    propertyMap,
                    destExpression
                );
        public TypePair GetAssociatedTypes(TypePair initialTypes)
        {
            return new TypePair(ContainerDef(initialTypes.SourceType), initialTypes.DestinationType);
        }
    }
    public class BaseContainerMapper
    {
        protected readonly Type genericContainerTypeDefinition;
        protected readonly String containerPropertyName;
        public BaseContainerMapper(Type GenericContainerTypeDefinition, String ContainerPropertyName)
        {
            genericContainerTypeDefinition = GenericContainerTypeDefinition;
            containerPropertyName = ContainerPropertyName;
        }
        protected ParameterExpression DigParameter(Expression e)
        {
            if (e is ParameterExpression pe) return pe;
            if (e is UnaryExpression ue) return DigParameter(ue.Operand);
            throw new ArgumentException("Couldn't find parameter");
        }
        public static Type ContainerDef(Type gen, Type to)
        {
            return new[] { to }.Concat(to.GetInterfaces())
                                .Where(x => x.IsGenericType)
                                .Where(x => gen.IsAssignableFrom(x.GetGenericTypeDefinition()))
                                .Select(x => x.GenericTypeArguments.Single())
                                .FirstOrDefault(); // Hopefully not overloaded!
        }
        protected Type ContainerDef(Type to)
        {
            return ContainerDef(genericContainerTypeDefinition, to);
        }
        protected PropertyInfo Of(Expression expr)
        {
            return expr.Type.GetTypeInfo().GetDeclaredProperty(containerPropertyName);
        }
    }
