           int numberOfYears;
            
            while (true)
            {
                Console.WriteLine("Not a valid ammount, try again.");
                if (!Int32.TryParse(Console.ReadLine(), out numberOfYears))
                    continue;
                            
                if (numberOfYears >= 1 && numberOfYears <= 10)
                {
                    Console.WriteLine("Valid value");
                    break;
                }
            }
