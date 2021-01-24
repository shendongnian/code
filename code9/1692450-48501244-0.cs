        private static void Main(string[] args)
        {
            List<int> InsertedNumbers = new List<int>(); //Create List before the loop
            Random rnd = new Random();
            int b = rnd.Next(1, 100);
            Console.WriteLine(b);
            int c;
            int NumberOfTries = 1;
            Console.WriteLine("Guess number from 1 to 100. You have 10 tries.");
            for (int i = 0; i <= 10; i++)
            {
                if (i == 10)
                {
                    Console.WriteLine("\nYou tried 10 times. Game is over!");
                    break;
                }
                Console.Write("\nGuess number: ");
                c = Convert.ToInt32(Console.ReadLine());
                InsertedNumbers.Add(c);
                if (c == b)
                {
                    Console.WriteLine("Bravo. You had {0} tries.", NumberOfTries);
                    foreach (int item in InsertedNumbers)
                    {
                        Console.WriteLine(item);
                    }
                    for (int j = 0; j < InsertedNumbers.Count; j++)
                    {
                        Console.WriteLine("{0}", InsertedNumbers[j]);
                    }
                    break;
                }
                else if (c < b)
                {
                    Console.WriteLine("No. My number is larger then " + c);
                    NumberOfTries++;
                }
                else if (c > b)
                {
                    Console.WriteLine("No. My number is smaller then " + c);
                    NumberOfTries++;
                }
            }
            Console.ReadLine();
        }
