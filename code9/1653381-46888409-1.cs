    public static string MyToJson<T>(this T entity)
    {
         var type = typeof(T);
         return type.FullName;
    }
