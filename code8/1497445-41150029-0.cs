    private static void RunArrayCode()
        {
            Random random = new Random();
            int[,] array = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    array[i, j] = random.Next();
                    // No tabs if it's the first item in a row
                    Console.Write("{0}{1}\t{2}", (j == 0 ? "" : "\t"), i, j);
                }
                // Each new row goes on its own line
                Console.WriteLine();
            }
        }
