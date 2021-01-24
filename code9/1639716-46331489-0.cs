    static void Main(string[] args)
    {
        var properties = TypeDescriptor.GetProperties(typeof(Request));
        var propItem = properties["Names"];
        var converter = propItem.Converter;
        // converter has type {EnumerableTypeConverter<string>}
    }
