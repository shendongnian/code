    private static void AddTwoArrays()
        {
            int size;
            Console.WriteLine("Enter a size:");
            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("Enter a valid int");
            }
            int[][] array1 = new int[size][];
            int[][] array2 = new int[size][];
            int sum = 0;
            int[] rowSum = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                array1[i] = new int[size];
                array2[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    array1[i][j] = random.Next(0, 5);
                    array2[i][j] = random.Next(0, 5);
                    // This is if you want to get the sum of every number contained in the array
                    sum += array1[i][j];
                    sum += array2[i][j];
                    // This'll give row-by-row
                    rowSum[j] += array1[i][j];
                    rowSum[j] += array2[i][j];
                }
            }
            Console.WriteLine("Sum: " + sum.ToString());
        }
