    class Program9
    {
        int input, i = 0, val, sum;
        decimal avg;
        public void program9M()
        {
            Console.Write("How many number(s) you have for an average: ");
            input = Convert.ToInt32(Console.ReadLine());
            if (input >= 2)
            {
                do
                {
                    i += 1;
                    Console.Write("Enter number {0} for an average: ", i);
                    val = Convert.ToInt32(Console.ReadLine());
                    sum = sum + val;
                    
                } while (i < input);
                avg = (decimal)sum / i;
                Console.WriteLine("The average of above {0} number is: {1}", i, avg);
            }
            else
            {
                Console.WriteLine("\n\nSorry you can't find average for one number, at least 2 number required\n\n");
            }
            Console.Write("Press any key to continue further...");
            Console.ReadKey();
        }
        public static void Main()
        {
            Program9 p9 = new Program9();
            p9.program9M();
        }
    }
}
