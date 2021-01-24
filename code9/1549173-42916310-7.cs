    public static void Main()
    {
            var pair1 = (42, "hello");
            System.Console.Write(Method(pair1).message);
    
            var pair2 = (code: 43, message: "world");
            System.Console.Write(pair2.message);
    }
