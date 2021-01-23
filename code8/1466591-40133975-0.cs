    void ProcessAnimals<T>(object o)
    {
        var type = o.GetType();
        var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(pi => pi.PropertyType.IsArray && pi.PropertyType.GetElementType().Equals(typeof(T)));
        foreach (var prop in props)
        {
            var array = (T[])prop.GetValue(o);
            foreach (var item in array)
            {
                //Do something
            }
        }
    }
