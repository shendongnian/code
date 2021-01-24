    public static Object fun(Object obj)
    {
       obj = 12;
       return obj;
    }
    static void Main(string[] args)
    {
       int value = 10;
       Object obj = value;
       obj = fun(obj);
       Console.WriteLine((int)obj);
    }
