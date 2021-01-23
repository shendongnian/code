    private static readonly Dictionary<int, string> dic = new Dictionary<int, string>
    {
        {1,"abc" },
        {2,"efg" },
        //...
    };
    public static string scoreColumn(int num)
    {
        if(!dic.ContainsKey(num)) return "";
        return dic[num];
    }
