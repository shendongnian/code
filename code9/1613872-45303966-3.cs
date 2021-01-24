    Type classType = Type.GetType("namespace.className");
    object classObject = classType.GetConstructor(Type.EmptyTypes).Invoke(new object[] { });
    
    foreach (KeyValuePair<string, object[]> methodInfo in methodsInfo)
    {
        classType.GetMethod(methodInfo.Key).Invoke(classObject, methodInfo.Value);
    }
