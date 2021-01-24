    public Form InstantiateFormFromTypeName(string typeName)
    {
        var type = System.Reflection.Assembly.GetExecutingAssembly()
           .GetTypes()
           .Where( t => t.Name == typeName )
           .Single();
        return Activator.CreateInstance(type);
    }
