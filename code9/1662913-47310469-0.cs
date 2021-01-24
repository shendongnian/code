    var nonGeneric = new NonGeneric();
    var generic = new Generic();
    string nonGenericName = nonGeneric.GetType().GetInterfaces().First().FullName;
    string genericName = generic.GetType().GetInterfaces().First().FullName;
    Console.WriteLine($"Non generic: {nonGenericName}");
    Console.WriteLine($"Generic: {genericName}");
