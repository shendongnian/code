    Assembly assembly = Assembly.Load(new AssemblyName("ClassLibrary1"));
    if (assembly == null)
    {
        return;
    }
    Type type = assembly.GetType("ClassLibrary1.Class1");
    object obj = Activator.CreateInstance(type);
    var method = type.GetMethod("Output");
    method.Invoke(obj, null);
