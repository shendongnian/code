    public static T CastToObject<T>(IDictionary<string, object> dict) where T : class
    {
       Type type = typeof(T);
       T result = (T)Activator.CreateInstance(type);
       foreach (var item in dict)
       {
           type.GetProperty(item.Key).SetValue(result, item.Value, null);
       }
       return result;
     }
