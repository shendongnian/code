    static void Action(int a)
    {
        Console.WriteLine(a);
    }
    
    static void Action(int a, int b)
    {
        Console.WriteLine(a + b);
    }
    
    static void Main(string[] args)
    {
        Dictionary<string, dynamic> Dic = new Dictionary<string, dynamic>();
        Dic.Add("ActionA", new Action<int>(Action));
        Dic.Add("ActionB", new Action<int, int>(Action));
        Dic["ActionB"](4, 5);
    }
