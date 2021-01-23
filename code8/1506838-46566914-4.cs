    var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("TestAssembly"), AssemblyBuilderAccess.Run);
    var moduleBuilder = assemblyBuilder.DefineDynamicModule("TestModule");
    var histBuilder = moduleBuilder.DefineType("Hist");
    var minProperty = histBuilder.CreateProperty<int?>("min");
    var maxProperty = histBuilder.CreateProperty<int?>("max");
    
    var processDataBuilder = moduleBuilder.DefineType("ProcessData");
    var histProperty = processDataBuilder.CreateProperty(histBuilder, "hist");
    processDataBuilder.CreateProperty<string>("id");
    processDataBuilder.CreateProperty<string>("source");
    processDataBuilder.CreateProperty<int?>("currentValue");
    
    processDataBuilder.CreateCalculatedProperty<int?>("min", histProperty.GetMethod, minProperty.GetMethod);
    processDataBuilder.CreateCalculatedProperty<int?>("max", histProperty.GetMethod, maxProperty.GetMethod);
