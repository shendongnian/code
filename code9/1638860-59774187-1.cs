    var interfaceType = interfaceProperty.DeclaringType;
    var interfaceMap = classProperty.DeclaringType.GetInterfaceMap(interfaceType);
    
    var gettersMatch = classProperty.CanRead && interfaceProperty.CanRead
        && MethodImplements(interfaceMap, interfaceProperty.GetMethod, classProperty.GetMethod);
    
    var settersMatch = classProperty.CanWrite && interfaceProperty.CanWrite
        && MethodImplements(interfaceMap, interfaceProperty.SetMethod, classProperty.SetMethod);
