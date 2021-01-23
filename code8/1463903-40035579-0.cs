    private static void Number()
        {
            Console.Write("Type it in a number: ");
            int num;
            var result = int.TryParse(Console.ReadLine(), out num);
            if (!result)
            {
                Console.WriteLine("Please type a number!");
            }
            else
            {
                Console.Write("Hi");
                // if user inter intiger then num will contain that
            }
            Console.ReadLine();
        }
