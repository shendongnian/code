    static void Main()
    {
        do
        {
            Console.Write("Timespan in seconds?: ");
            int timeInSeconds;
            if (int.TryParse(Console.ReadLine(), out timeInSeconds))
            {
                Console.WriteLine("This is:");
                double amountOfDays = timeInSeconds / 86400;
                if (amountOfDays != 0)
                    Console.WriteLine($"- {(int)amountOfDays} days");
                double amountOfHours = timeInSeconds / 3600 - ((int)amountOfDays * 24);
                if (amountOfHours != 0)
                    Console.WriteLine($"- {(int)amountOfHours} hours");
                double amountOfMinuts = timeInSeconds / 60 - ((int)amountOfHours * 60) - ((int)amountOfDays * 24 * 60);
                if (amountOfMinuts != 0)
                    Console.WriteLine($"- {(int)amountOfMinuts} minuts");
                double amountOfSeconds = timeInSeconds - ((int)amountOfMinuts * 60) - ((int)amountOfHours * 60 * 60) - ((int)amountOfDays * 24 * 60 * 60);
                if (amountOfSeconds != 0)
                    Console.WriteLine($"- {(int)amountOfSeconds} seconds");
            }
            else
            {
                Console.WriteLine("Please enter a positive integer!");
            }
        } while (true);
    }
