    public static decimal[] PromptForDecimals(string[] array1)
        {
            decimal[] inputArray = new decimal[array1.Length];
            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine("");
                string inputString = Console.ReadLine();
    
                decimal input;
                while (!decimal.TryParse(inputString, out input))
                {
                    Console.WriteLine("Please enter a number value.");
                    inputString = Console.ReadLine();
                }
                   
                inputArray[i] = input;
    
                return inputArray;
