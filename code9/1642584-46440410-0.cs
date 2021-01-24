    class Program
    {
        public static void Hello1()
        {
            Console.WriteLine("\nHello 1");
        }
        public static void Hello2()
        {
            Console.WriteLine("\nHello 2");
        }
        static void Main(string[] args)
        {
            while (true)
            {
                String method = Console.ReadLine();
                Type methodType = typeof(Program);
                MethodInfo voidMethodInfo = methodType.GetMethod(method);
                voidMethodInfo.Invoke(method,null);
            }
        }
    }
