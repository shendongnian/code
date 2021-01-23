    public static void Main()
    {
        int[,] a = new int[2, 2];
        int[,] b = new int[2, 2];
        int[,] c = new int[2, 2];
        int sum1 = 0;
        int sum2 = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write("Please enter {0}. Mark of First lesson", i + 1, j + 1);
                a[i, j] = Int32.Parse(Console.ReadLine());
                sum1 += a[i,j]; 
            }
        }
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write("Please enter {0}. Mark of Second lesson", i + 1, j + 1);
                b[i, j] = Int32.Parse(Console.ReadLine());
                sum2 += b[i, j];
            }
        }
        Console.WriteLine("Sum: " + (sum1 + sum2));
        //for (int i = 0; i < 2; i++)
        //{
        //    for (int j = 0; j < 2; j++)
        //    {
        //        c[i, j] = a[i, j] + b[i, j];
        //        Console.WriteLine("{0}." + c[i, j], i + 1 + "The sum of 2 marks is:", j + 1);
        //    }
        //}
        Console.Read();
    }
