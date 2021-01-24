        static void Main(string[] args)
        {
            Console.WriteLine("Enter a String and a number : ");
            Console.Read();
            if(args.Length >= 2)
            {
                string str = args[0];
                int n = Convert.ToInt32(args[1]);
                Console.WriteLine(str);
                Console.WriteLine(n);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No Args passed");
            }
        }
