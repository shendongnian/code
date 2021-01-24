    public Form InstantiateFormFromTypeName(string typeName)
    {
        var type = System.Reflection.Assembly.GetExecutingAssembly()
           .GetTypes()
           .Where
           (
               t => t.FullName == typeName 
                 && typeof(Form).IsAssignableFrom(t)
           )
           .Single();
        return Activator.CreateInstance(type) as Form;
    }
