    public static PropertyInfo GetPropertyOfInterface(Type interfaceType, string propertyName)
    {
        if (interfaceType == null)
            throw new ArgumentNullException("interfaceType");
        if (!interfaceType.IsInterface)
            throw new ArgumentException(
                string.Format("Type {0} doesn't represent an interface.",
                    interfaceType.FullName),
                "interfaceType");
        // If declared in given interface, just return that.
        var declaredProperty = interfaceType.GetProperty(propertyName);
        if (declaredProperty != null)
            return declaredProperty;
        // Otherwise, first finding all the candidates.
        var candidates = new HashSet<PropertyInfo>(
            interfaceType.GetInterfaces().Select(t => t.GetProperty(propertyName)));
        candidates.Remove(null);
        if (candidates.Count == 0)
            throw new ArgumentException(
                string.Format("Property {0} not found in interface {1}.",
                    propertyName, interfaceType.FullName),
                "propertyName");
        // Finally, removing all candidates the first candidates hide.
        var originalCandidates = candidates.ToList();
        candidates.ExceptWith(
            originalCandidates.SelectMany(prop => prop.DeclaringType.GetInterfaces())
                              .Select(t => t.GetProperty(propertyName)));
        if (candidates.Count != 1)
            throw new AmbiguousMatchException(
                string.Format("Property {0} is ambiguous in interface {1}.",
                    propertyName, interfaceType.FullName));
        return candidates.First();
    }
