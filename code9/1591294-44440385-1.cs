    public static IPrint GetPrint(PrintType type)
    {
        IPrint print;
        if (!prints.TryGetValue(type, out print))
           return null;
        return print;
    }
