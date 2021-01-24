        public static bool BetweenRanges(int a, int b, int number)
        {
            return (a <= number && number <= b);
        }
        static void Main(string[] args)
        {
            bool notValid = true;
            while (notValid)
            {
                try
                {
                    Console.WriteLine("Enter the number of years:");
                    int numberOfYearsInput = Convert.ToInt16(Console.ReadLine());
                    while (!BetweenRanges(1, 10, numberOfYearsInput))
                    {
                        Console.WriteLine("Not a valid ammount, try again.");
                        numberOfYearsInput = Convert.ToInt16(Console.ReadLine());
                    }
                    notValid = false;
                }
                catch
                {
                    Console.WriteLine("Text is not valid ammount, try again.\n");
                }
            }
        }
