    static IEnumerable<MethodInfo> GetMethods(Type type) {
        foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static |
                                                   BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)) {
            yield return method;
        }
        if (type.IsInterface) {
            foreach (var iface in type.GetInterfaces()) {
                foreach (var method in GetMethods(iface)) {
                    yield return method;
                }
            }
        }
    }
