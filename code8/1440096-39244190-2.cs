    private static IEnumerable<PropertyInfo> GetPropertiesExcept<T>(object p)
    {
        BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly |
                                    BindingFlags.FlattenHierarchy;
        PropertyInfo[] iNewPropertyInfos = typeof (T).GetProperties(bindingFlags);
        return p.GetType().GetProperties(bindingFlags).Where(x => iNewPropertyInfos.All(y => y.ToString() != x.ToString()));
    }
