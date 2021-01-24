        int[] numbers = new int[2];
        for (int i = 0; i < numbers.Length; i++)
        {
            var number = Console.ReadLine();
            if (int.TryParse(number, out int numberTry) && i == 0)
            {
                Console.WriteLine("That would be a number yes.");
                numbers[i] = numberTry;
            }
            else if (int.TryParse(number, out numberTry))
            {
                Console.WriteLine("Lovely work! That is indeed two numbers!");
                numbers[i] = numberTry;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("That's not a number. I am dissapointed.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        Console.ReadKey();
