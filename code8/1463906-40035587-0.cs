    private static void Number()
        {
            Console.Write("Type it in a number: ");
            string userInput = Console.ReadLine();
            int result;
            bool isValidNumber = Int32.TryParse(userInput,out result);
            if (isValidNumber)?
            Console.WriteLine("Please type a number!"):                        Console.Write("Hi");
            
            Console.ReadLine();
        }
