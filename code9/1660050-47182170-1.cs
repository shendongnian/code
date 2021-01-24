    class Program
    {    
        static void Main(string[] args)
        {
            Random GenerateNumber = new Random();
            int[] number = new int[6];
            Generating(GenerateNumber, number);
            Ordering(number);
        }
    
        static void Generating(Random generateNumber, int[] number)
        {
            Console.Clear();
            Console.WriteLine("Stage 1 : 6 random numbers have been generated:\n");
            for (int c = 0; c < number.Length; c++)
            {
                if (number[c] == 0)
                {
                    number[c] = generateNumber.Next(1, 50);
                    Console.Write("Random number " + (c + 1) + " = " + number[c] + "\n");
                }
            }
        }
    
        static void Ordering(int[] number)
        {
            Console.Clear();
            for (int i = 0; i < number.Length; i++)
            {
                Array.Sort(number);
                Console.Write("Number " + (i + 1) + " = " + number[i] + "\n");
            }
        }
    }
