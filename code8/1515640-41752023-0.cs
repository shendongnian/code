    static void Main(string[] args)
        {
            int k;
            int[] x = new int[20];
            int[] y = new int[20];
            int[] yval = new int[20];
            int i;
            Console.WriteLine("Enter k value");
            k = Console.Read();
            Console.WriteLine("k = {0}", k);
            Console.WriteLine("Enter x values\n ");
            for (i = 0; i <= 19; i += 1)
            {
                var input = Console.ReadLine();
                x[i] = int.Parse(input);
                yval[i] = (x[i] + k) % 26;
                Console.WriteLine("x[{0}] = {1}", i, x[i]);
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
