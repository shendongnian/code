    Expression<Func<double, double, double, double>> myexp = (a, b, c) => a * b * c;
    var methodName = "DynamicMethod";
    
    var asmName = new AssemblyName("DynamicAssembly");
    var asmBuilder = AssemblyBuilder.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);
    var moduleBuilder = asmBuilder.DefineDynamicModule("DynamicModule");
    var typeBuilder = moduleBuilder.DefineType("DynamicType", TypeAttributes.Public);
    var methodBuilder = typeBuilder.DefineMethod(methodName, MethodAttributes.Static, typeof(double), new[] { typeof(double), typeof(double), typeof(double) });
    
    myexp.CompileToMethod(methodBuilder);
    var type = typeBuilder.CreateType();
    var method = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);
    
    asmBuilder.SetEntryPoint(method);
    MethodInfo barMethod = asmBuilder.EntryPoint;
    var result = barMethod.Invoke(null, new object[] { 50d, 1d, 3d });
