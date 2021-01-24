        static void Main(string[] args)
        {
            Console.WriteLine("Enter a String and a number, with a space between: ");
            string consoleRead = Console.ReadLine();
            string[] parsed = consoleRead.Split(' ');
            if (parsed.Length > 1)
            {
                string str = parsed[0];
                int n = Convert.ToInt32(parsed [1]);
                Console.WriteLine(str);
                Console.WriteLine(n);
                Console.ReadKey();
            }
        }
