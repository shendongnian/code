    public class JsonWhiteListInterfaceBinder : InterfaceBinder
    {
        #region Constructors
        public JsonWhiteListInterfaceBinder(TypeResolverOptions options) : base(options)
        {
        }
        #endregion
        public override List<Type> ConcreteTypesFromInterface(Type interfaceType)
        {
            var interfaceTypeInfo = interfaceType.GetTypeInfo();
            if (interfaceTypeInfo.IsGenericType && (false == interfaceTypeInfo.IsGenericTypeDefinition))
            {
                interfaceType = interfaceTypeInfo.GetGenericTypeDefinition();
            }
            this._options.TypeResolverMap.TryGetValue(interfaceType, out var types);
            return types ?? new List<Type>();
        }
        public override Type ConvertType(Type expectedType, Type interfaceType)
        {
            if (expectedType.GetTypeInfo().IsGenericTypeDefinition && interfaceType.GetTypeInfo().IsGenericType)
            {
                var arguments = interfaceType.GetTypeInfo().GetGenericArguments();
                return expectedType.GetTypeInfo().MakeGenericType(arguments);
            }
            return expectedType;
        }
    }
