    var declaredType = GetDeclaringType(ctor); //MyGeneric<>
    var closedType = declaredType.MakeGenericType(typeof(int));//MyGeneric<int>
    //constructors
    var typeInfo = closedType.GetTypeInfo();
    var constructors = typeInfo.GetConstructors();
    //MyGeneric<int>..ctor(int, double)
    var constructorWithDouble = constructors
        .Where(ctor => ctor.GetParameters().Skip(1).First().ParameterType == typeof(double))
        .First();
