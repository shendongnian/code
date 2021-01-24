     private static string name = null;
        static void Main(string[] args)
        {
            SetName();
            Console.WriteLine("Name: " + ReturnName(name));
            Console.ReadKey();
        }
        private static void SetName()
        {
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
        }
        public static string ReturnName(string name)
        {
            return name;
        }
