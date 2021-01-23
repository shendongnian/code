        public static void Main()
        {
            var s = new StringBuilder();
            Console.WriteLine(s.ToString());
            SayHello(s);
            Console.WriteLine(s.ToString());
            Console.ReadLine();
        }
        private static void SayHello(StringBuilder s)
        {
            s.AppendLine("Hello");
            s = null;
        }
        //output will be Hello
