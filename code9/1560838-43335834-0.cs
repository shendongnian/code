    class Example
    {
        public static void Test<T>(T argument)
        {
            Console.WriteLine("First prototype called.");
        }
        public static void Test<T>(IList<T> argument)
        {
            Console.WriteLine("Second prototype called.");
        }
        public static void Test<T>(List<T> argument)
        {
            Console.WriteLine("Third prototype called.");
        }
        static public void TryItout()
        {
            var s = "Hello";
            var l = new List<string>();
            IList<string> i = l;
            Example.Test(s);   //First prototype called
            Example.Test(i);   //Second prototype called
            Example.Test(l);   //Third prototype called
            Example.Test<string>(s);        //First prototype called
            Example.Test<IList<string>>(i); //First prototype called
            Example.Test<IList<string>>(l); //First prototype called
            Example.Test<List<string>>(l);  //First prototype called
        }
    }
