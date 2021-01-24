    //MyGeneric<>
    var genericType = typeof(MyGeneric<>);
    //MyGeneric<int>
    var closedType = genericType.MakeGenericType(typeof(int));
    //MyGeneric<DateTime>
    closedType = genericType.MakeGenericType(typeof(DateTime));
    //constructors
    var typeInfo = closedType.GetTypeInfo();
    var constructors = typeInfo.GetConstructors();
    //MyGeneric<DateTime>..ctor(DateTime, double)
    var constructorWithDouble = constructors
        .Where(ctor => ctor.GetParameters().Skip(1).First().ParameterType == typeof(double));
