    public void Demo()
    {
        var parent = typeof(UserControl);
        var currentNamespace = GetType().Namespace;
        var controls = GetType().Assembly.GetTypes()
            .Where(t => t.Namespace == currentNamespace 
                && parent.IsAssignableFrom(t))
            .ToList();
    }
