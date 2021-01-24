    static void RefClean(ref String arg){
        arg = null;
    }
    static void Main(string[] args)
    {
        var test = "Hello";
        Console.WriteLine(test == null);
        RefClean(ref test);
        Console.WriteLine(test == null);
    }
