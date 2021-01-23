    AssemblyName assemblyName
    = new AssemblyName("MyDynamicAssembly");
    AssemblyBuilder assemblyBuilder
        = AppDomain.CurrentDomain.DefineDynamicAssembly(
            assemblyName,
            AssemblyBuilderAccess.Run);
    ModuleBuilder moduleBuilder
        = assemblyBuilder.DefineDynamicModule("MyDynamicModule");
    TypeBuilder typeBuilder
        = moduleBuilder.DefineType("Sample");
    var obj = Activator.CreateInstance(typeBuilder.CreateType());
    var pi = obj.GetType().GetProperty("Children");
    var ct = Convert.ChangeType(obj, pi.PropertyType) as IEnumerable<object>;
    var results = (ct as IEnumerable<object>).Traverse(s => s.Equals("1"));
