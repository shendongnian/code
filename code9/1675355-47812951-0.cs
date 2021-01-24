    public static void patchObject<TObject>(this TObject target, Dictionary<string, object> values) where TObject : class {
        if (target != null) {
            foreach (var kvp in values) {
                updateObjectPropertyCore<TObject>(target, kvp.Key, kvp.Value);
            }
        }
    }
    private static void updateObjectPropertyCore<TObject>(TObject target, string propertyName, object value) where TObject : class {
        var type = typeof(TObject);
        var property = type.GetPropertyCaseInsensitive(propertyName);
        if (property != null && property.CanWrite) {
            property.SetValue(target, value);
        }
    }
    /// <summary>
    /// Gets a property by name, ignoring case and searching all interfaces.
    /// </summary>
    /// <param name="type">The type to inspect.</param>
    /// <param name="propertyName">The property to search for.</param>
    /// <returns>The property or null if not found.</returns>
    public static PropertyInfo GetPropertyCaseInsensitive(this Type type, string propertyName) {
        var typeList = new List<Type> { type };
        if (type.IsInterface()) {
            typeList.AddRange(type.GetInterfaces());
        }
        var flags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;
        return typeList
            .Select(interfaceType => interfaceType.GetProperty(propertyName, flags))
            .FirstOrDefault(property => property != null);
    }
