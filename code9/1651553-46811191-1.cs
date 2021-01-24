        var properties1 = new List<PropertyInfo>();
            foreach (var p in entities.GetType().GetGenericArguments().Single().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (p.PropertyType.IsAssignableFrom(c: typeof(Nullable<>)) || Type.GetTypeCode(p.PropertyType) != TypeCode.Object) properties1.Add(p);
            }
