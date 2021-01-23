    static void Main(string[] args)
    {
        Console.WriteLine(MyClass.GetTexted);
    }
    class MyClass
    {
        private static string dontTouchMe = "test";
        public static string GetTexted { get { return dontTouchMe + "1"; } }
        //public static string GetTexted => dontTouchMe + "1";
    }
