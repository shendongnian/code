        public static IEnumerable<Type> GetByInterfaceAndGeneric(Type interfaceWithParam, Type specificTypeParameter)
        {
            var query =  
                from x in specificTypeParameter.Assembly.GetTypes()
                where 
                x.GetInterfaces().Any(k => k.Name == interfaceWithParam.Name && 
                k.Namespace == interfaceWithParam.Namespace && 
                k.GenericTypeArguments.Contains(specificTypeParameter))
                select x;
            return query;
        }
