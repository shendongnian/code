    Type def = typeof(Foo<>);
    Type[] defparams = def.GetGenericArguments();
    Console.WriteLine(defParams[0].Name); // writes "TData"
    Console.WriteLine(defParams[0].GenericParameterPosition); // writes 0
    
    Type concreteDef = typeof(Foo<string>)
    Type[] concreteDefParams = concreteDef.GetGenericArguments();
    Console.WriteLine(concreteDefParams[0].FullName); // writes "System.String"
