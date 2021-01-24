        var value1 = (IEnumerable)prop.GetValue(first, null);
        var value2 = (IEnumerable)prop.GetValue(second, null);
        if (object.Equals(value1, value2))
            continue;
        if (prop.PropertyType != typeof(IEnumerable)) {
            var ienumt = prop.PropertyType.GetInterfaces().Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>)).FirstOrDefault();
            if (ienumt != null) {
                var t = ienumt.GetGenericArguments(); // T of IEnumerable<T>
                if ((t[0].IsClass || t[0].IsInterface) && t[0] != typeof(string)) {
                    continue;
                }
                var method = CompareCollectionMethod.MakeGenericMethod(t);
                var result = (IEnumerable<NonEqualProperty>)method.Invoke(null, new[] { value1, value2 });
                list.AddRange(result);
                continue;
            }
        }
                
        if (value1 == null || value2 == null) {
            list.Add(new NonEqualProperty(prop.Name, value1, value2));
            continue;
        }
        // continue with the code for non-generic IEnumerable
        IEnumerator enu1 = null, enu2 = null;
