    private static int[,] array = { { 0, 0, 1, 1 }, { 0, 0, 0, 1 }, { 0, 1, 1, 1 }, { 1, 0, 1, 0 } };
        static void Main(string[] args)
        {
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= array.GetUpperBound(1); j++)
                {
                    Console.Write(TestZero(array, i, j) + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
