    private static readonly Dictionary<int, string> dic = new Dictionary<int, string>
    {
        {1,"abc" },
        {2,"efg" },
        //...
    };
    public static string scoreColumn(int num)
    {
        string val;
        if(dic.TryGetValue(num, out val)) return val;
        else return "";
    }
