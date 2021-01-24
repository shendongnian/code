    public static Dictionary<string, Type> returnDic()
    {
        var types = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "ConsoleApplication11.Packets");
        var Dic = new Dictionary<string, Type>();
        foreach (var t in types)
        {
            Dic.Add(t.Name, t);
        }
        return Dic;
    }
