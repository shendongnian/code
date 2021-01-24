    HashSet<string> allNamespaces = new HashSet<string>(
        AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Select(t => t.Namespace)
        );
    bool isNamespace = allNamespaces.Contains("foo");
