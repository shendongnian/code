Based on Mark Saphiro answer I changed a litle bit the code to avoid reference cycles. I save the visited objects in a HashSet and only recurse if an object is a class and it's not in the set.
    HashSet<object> hashSet = new HashSet<object>();
    public static T SetEmptyPropertiesNull<T>(T request)
    {
        foreach (PropertyInfo property in typeof(T).GetProperties())
        {
            object value = property.GetValue(request, null);
            if (typeof(value).IsClass && !hashSet.Contains(value))
            {
                hashSet.Add(value);
                SetEmptyPropertiesNull(value);
            }
            else if (string.IsNullOrWhiteSpace((value ?? string.Empty).ToString()))
                property.SetValue(request, null);
         }
         return request;
    }
