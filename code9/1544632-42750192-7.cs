     var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(
         new AssemblyName("dynamic_asm"),
         AssemblyBuilderAccess.Save);
     var module = asm.DefineDynamicModule("dynamic_mod", "dynamic_asm.dll");
     var type = module.DefineType("DynamicType");
     var method = type.DefineMethod(
         "DynamicMethod", MethodAttributes.Public | MethodAttributes.Static);
     Expression.Lambda<Func<double>>(sum).CompileToMethod(method);
     type.CreateType();
     asm.Save("dynamic_asm.dll");
