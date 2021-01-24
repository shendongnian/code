    Type childType = typeof(Child);
    MethodInfo childPut = childType.GetMethod("Put");
    Type declaringType = childPut.DeclaringType;
    if (declaringType.IsGenericType)
    {
        Type genericType = declaringType.GetGenericTypeDefinition();
        MethodInfo genericMethod = genericType.GetMethod("Put");
        ParameterInfo genericParam = genericMethod.GetParameters().First();
        Console.WriteLine(genericParam.ParameterType.IsGenericParameter);
    }
