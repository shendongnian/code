    var assemblyNames = new[]
    {
        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
        "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
        "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
    };
    var nss = new[]
    {
        "System.Threading"
    };
    // Begin real code
    var assemblies = Array.ConvertAll(assemblyNames, Assembly.Load);
    var nss2 = Array.ConvertAll(nss, x => x + ".");
    var types = assemblies.SelectMany(x => x.ExportedTypes).Where(x => nss2.Any(y => x.FullName.StartsWith(y))).ToArray();
    // The Delegate check is taken from http://mikehadlow.blogspot.it/2010/03/how-to-tell-if-type-is-delegate.html
    var classes = types.Where(x => !typeof(Delegate).IsAssignableFrom(x)).ToArray();
    var structs = types.Where(x => x.IsValueType && !x.IsEnum).ToArray();
    var enums = types.Where(x => x.IsEnum).ToArray();
    var delegates = types.Where(x => typeof(Delegate).IsAssignableFrom(x)).ToArray();
    // There is a DeclaringType property to see what Type is declaring them
    var constructors = types.SelectMany(x => x.GetConstructors(BindingFlags.Public | BindingFlags.Instance)).ToArray();
