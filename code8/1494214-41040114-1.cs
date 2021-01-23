    static void Main(string[] args)
        {
            int[,] myArr2D;
           myArr2D = new int[3, 3];
            myArr2D[0, 0] = 10;
            myArr2D[0, 1] = 11;
            myArr2D[0, 2] = 12;
            myArr2D[2, 0] = 13;
            myArr2D[1, 2] = 14;
            int sum = myArr2D.Cast<int>().Sum();
            Console.WriteLine(sum); // 60
            Console.ReadKey();
        }
