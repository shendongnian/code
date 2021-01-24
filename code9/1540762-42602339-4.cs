        static public int DisplayMenu()
        {
            Console.Clear();
            while(true)
            {
                Console.WriteLine("");
                Console.WriteLine();
                Console.WriteLine("1. Quick Clean");
                Console.WriteLine("2. Deep Clean");
                Console.WriteLine("3. Super Clean (admin needed)");
                Console.WriteLine("4. exit");
                int result;
                if(Int32.TryParse(Console.ReadLine(), out result))
                    return result;
                else
                    Console.WriteLine("Please enter a number");
            }
         }
