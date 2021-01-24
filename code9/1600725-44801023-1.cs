            int numberOfYears;
            Console.WriteLine("Enter the number of years:");
            string numberOfYearsInput = Console.ReadLine();
            bool result = false;
            while (!result)
            {
                if (Int32.TryParse(numberOfYearsInput, out numberOfYears))
                {
                    if (numberOfYears < 1 || numberOfYears > 10)
                    {
                        Console.WriteLine("Not a valid ammount, try again.");
                        numberOfYearsInput = Console.ReadLine();
                    }
                    else
                    {
                        result = true;
                        Console.WriteLine("Correct Number");
                        Console.ReadKey(true);
                        //Do your code here
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid number, try again.");
                    numberOfYearsInput = Console.ReadLine();
                }
            }
