    Type childType = typeof(Child);
    MethodInfo childPut = childType.GetMethod("Put");
    // get the type that initially declared the method
    Type declaringType = childPut.DeclaringType;
    if (declaringType.IsGenericType)
    {
        // get the generic type definition (not the constructed Parent<int>)
        Type genericType = declaringType.GetGenericTypeDefinition();
        MethodInfo genericMethod = genericType.GetMethod("Put");
        ParameterInfo genericParam = genericMethod.GetParameters().First();
        // use IsGenericParameter - we want to know that the type is determined
        // by a generic argument, not if that type argument itself is generic
        Console.WriteLine(genericParam.ParameterType.IsGenericParameter);
    }
