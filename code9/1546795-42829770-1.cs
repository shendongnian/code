    Type t = typeof(Test);
    var assemblies = t.Assembly.GetReferencedAssemblies();
    foreach (var item in assemblies)
    {
            Console.WriteLine(item.Name);
    }
