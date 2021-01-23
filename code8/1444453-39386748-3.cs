    public static object CreateGeneric(string type)
    {
        switch (type)
        {
            case "string": return new GenericString();
            case "int":    return new GenericInt();
            default:       throw new InvalidOperationException("Invalid type specified.");
        }
    }
