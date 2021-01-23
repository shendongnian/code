        static void Main(string[] args)
        {            
            bool print = true;
            while (print)
            {
                Console.Write("Enter the number of times to print \"Yay!\": ");
                string entry = Console.ReadLine();
                try
                {
                    var number = int.Parse(entry);
                    for (int i = 0; i < number; i++)
                    {
                        Console.WriteLine("Yay!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a whole number.");
                }
            }
        }
