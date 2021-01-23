    static class TypeExtensions
    {
        public static string[] GetPropertyNames(this Type type) =>
            type
                .GetProperties()
                .Select(prop => prop.Name)
                .ToArray();
    }
    ...
    foreach (string prop in typeof(Table).GetPropertyNames())
        Console.WriteLine(prop);
