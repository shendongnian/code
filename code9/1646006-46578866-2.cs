        public static void Main(string[] args)
        {
            Action[] actionsArray =
            {
                () => MethodA(),
                () => MethodB1()
            };
            Parallel.Invoke(actionsArray);
            MethodB2();
        }
        private static void MethodA()
        {
            Console.WriteLine("A");
            Thread.Sleep(3000);
            // more code is running here (30 min)
        }
        private static void MethodB1()
        {
            Console.WriteLine("B1");
            Thread.Sleep(200);
            // more code is running here (2 min)
        }
        private static void MethodB2()
        {
             Console.WriteLine("B2");
        }
