    static void Main(string[] args)
    {
        testme("DD", "jj");
        Console.ReadLine();
    }
    
       
    public static void testme(string d="", string s = "")
    {
        if (string.IsNullOrWhiteSpace(d) && string.IsNullOrWhiteSpace(s))
            return;
        if(string.IsNullOrEmpty(d))
            Console.Write(s);
        if (string.IsNullOrEmpty(s))
            Console.Write(d);
    }
