    var assembly = Assembly.Load(File.ReadAllBytes(some_path));
    // This will work. Note that you don't need the assembly-qualified name,
    // as you are asking the assembly directly for the type.
    var type1 = assembly.GetType("My.Special.Type");
    // This will not work - the assembly "My.Assembly" is not loaded into
    // the Load context, so the type is not available.
    var type2 = Type.GetType("My.Special.Type, My.Assembly");
