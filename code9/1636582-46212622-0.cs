    Type MakeGenericType(Type type, Type parameter)
    {
        if (!type.ContainsGenericParameters)
            throw new ArgumentException(nameof(type));
    
        bool replaced = false;
    
        return MakeGenericType(type, parameter, ref replaced);
    }
    
    Type MakeGenericType(Type type, Type parameter, ref bool replaced)
    {
        if (type.IsGenericParameter)
            if (replaced)
                return type;
            else
            {
                replaced = true;
                return parameter;
            }
    
        if (type.IsGenericTypeDefinition)
        {
            var parameters = type.GetTypeInfo().GenericTypeParameters.ToArray();
    
            parameters[0] = parameter;
            replaced = true;
    
            return type.MakeGenericType(parameters);
        }
    
        if (type.IsGenericType && type.ContainsGenericParameters)
        {
            var parameters = type.GenericTypeArguments.ToArray();
    
            for (int i = 0; i < parameters.Length; i++)
                parameters[i] = MakeGenericType(parameters[i], parameter, ref replaced);
    
            return type
                .GetGenericTypeDefinition()
                .MakeGenericType(parameters);
        }
    
        return type;
    }
