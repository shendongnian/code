    public static void fun(ref Object obj)
    {
       obj = 12;
    }
    static void Main(string[] args)
    {
       int value = 10;
       Object obj = value;
       fun(ref obj);
       Console.WriteLine((int)obj);
    }
