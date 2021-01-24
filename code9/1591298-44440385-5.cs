    public static IPrint GetPrint(PrintType type)
    {
        Lazy<IPrint> factory;
        if (!prints.TryGetValue(type, out factory))
           return null;
        return factory.Value;
    }
