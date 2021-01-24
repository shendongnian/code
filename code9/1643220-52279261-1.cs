    var assemblies = AppDomain.CurrentDomain
                           .GetAssemblies()
                           .Where(a => !a.IsDynamic)
                           .Where(a => !parameters.ReferencedAssemblies.Contains(a.Location))
                           .Select(a => a.Location);
    parameters.ReferencedAssemblies.AddRange(assemblies.ToArray());
