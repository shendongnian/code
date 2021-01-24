    private List<string> ListReferencedAssemblies()
    {
        List<string> refList = new List<string>();
        var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
        foreach (var assembly in assemblies)
        {
            refList.Add(assembly.Name);
        }
        
        return refList;
    } 
