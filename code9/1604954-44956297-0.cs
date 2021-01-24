    if (Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                    .FirstOrDefault(c => c.FullName == "This.Is.My.Assembly.Name") == null)
    {
        var assembly = Assembly.Load("This.Is.My.Assembly.Name");
    }
