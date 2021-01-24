    class program
    {
        public static void Main()
        {
            int[,] arr = new int[3, 3];
            Console.WriteLine("Enter elements of " + (arr.GetUpperBound(0) + 1) + "x" + (arr.GetUpperBound(1) + 1) + " matrix:");
            for (int i = 0; i < (arr.GetUpperBound(0) + 1); i++)
            {
                for (int j = 0; j < (arr.GetUpperBound(1) + 1); j++)
                {
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Matrix entered: ");
            for (int i = 0; i < (arr.GetUpperBound(0) + 1); i++)
            {
                for (int j = 0; j < (arr.GetUpperBound(1) + 1); j++)
                {
                    Console.Write("\t" + arr[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Possible sub-matrices: ");
            for (int i = 0; i < 3; i++)
            {
               for (int j = 0; j< 3; j++)
                 {
                    TrimArray(i,j,arr);
                 }    
            }
        }
        public static int[,] TrimArray(int row, int column, int[,] original)
        {
            int[,] resultant = new int[original.GetLength(0) - 1, original.GetLength(1) - 1];
            for (int i = 0, j = 0; i < original.GetLength(0); i++)
            {
                if (i == row)
                    continue;
                for (int k = 0, u = 0; k < original.GetLength(1); k++)
                {
                    if (k == column)
                        continue;
                    resultant[j, u] = original[i, k];
                    u++;
                }
                j++;
            }
            Console.WriteLine();
            for (int i = 0; i < 2; i++)
            {
                    for (int j = 0; j< 2; j++)
                   {
                        Console.Write("\t"+resultant[i,j]);
                   }
                    Console.WriteLine();
            }
            return resultant;
        }
    } 
