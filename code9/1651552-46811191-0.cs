     var properties1 = new List<PropertyInfo>();
     foreach (var p in entities.GetType().GetGenericArguments().Single().GetProperties(BindingFlags.Instance | BindingFlags.Public))
       {
         if (Type.GetTypeCode(p.PropertyType) != TypeCode.Object || p.PropertyType.IsAssignableFrom(c: typeof(Nullable<>))) properties1.Add(p);
       }
