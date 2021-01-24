        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string answer = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            switch (password)
            {
                case "12345":
                    Console.WriteLine("Welcome " + answer);
                    break;
                case "hyperion":
                    Console.WriteLine("Welcome" + answer);
                    break;
                case "CSGOPRO":
                    Console.WriteLine("Welcome " + answer);
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
