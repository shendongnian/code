    var externalDll = Assembly.LoadFile("c:\\somefolder\\Customer.dll");
    var externalTypeByName = externalDll.GetType("CustomerClassNamespace.Customer");
    
    // If you don't know the full type name, use linq
    var externalType = externalDll.ExportedTypes.FirstOrDefault(x => x.Name == "Customer");
    
    //if the method is not static create an instance.
    //using dynamic 
    dynamic dynamicInstance = Activator.CreateInstance(externalType);
    var dynamicResult = dynamicInstance.show();
    // or using reflection
    var reflectionInstance = Activator.CreateInstance(externalType);
    var methodInfo = theType.GetMethod("show");
    var result = methodInfo.Invoke(reflectionInstance, null);
    
    // Again you could also use LINQ to get the method
    var methodLINQ = externalType.GetMethods().FirstOrDefault(x => x.Name == "show");
    var resultLINQ = methodLINQ.Invoke(reflectionInstance, null);
