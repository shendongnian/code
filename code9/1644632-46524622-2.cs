      static void Main(string[] args)
        {
            string name = SetName();
            Console.WriteLine("Name: " + name);
        }
        private static string GetName()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            return name;
        }
