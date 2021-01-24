    using System;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Please provide a number and press 'Enter'");
                var input = Console.ReadLine();
    
                int lenght;
                if (!int.TryParse(input, out lenght))
                {
                    lenght = 10;
                }
                int l = 13;
                int[] rolls = new int[l];
    
                var rnd = new Random();
    
                for (int i = 1; i < lenght; i++)
                {
                    int index = rnd.Next(1, 7) + rnd.Next(1, 7);
                    //MessageBox.Show(index + ""); THIS LINE IS REQUIRED
                    rolls[index] += 1;
                }
    
                for (int i = 0; i < l; i++)
                {
                    Console.WriteLine($"rolls[{i}] = {rolls[i]}");
                }
    
                Console.WriteLine("Done. Prss any key to exit");
                Console.ReadKey();
            }
        }
    }
