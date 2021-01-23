    static void Main(string[] args)
        {
            int Height = 4;
            int Width = 5;
            int[,] grid = new int[Height, Width];
            Console.Write("Start Number :");
            int startnum = int.Parse(Console.ReadLine());
            Console.Write("End Number :");
            int endnum = int.Parse(Console.ReadLine());
            Console.Write("input nmber of cells to be offset at max "+Width*Height+" :");
            int cellofs = int.Parse(Console.ReadLine());
            var myNumbers = Enumerable.Range(startnum, endnum).ToArray();
            int t = 1;
            for(int i=cellofs;i<Width*Height;i++)
            {
                int iline = i / Width;
                int jcol = i % Width;
                if (t <= (endnum - startnum))
                {
                    grid[iline, jcol] = myNumbers[t];
                    t++;
                }
            }
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(grid[i, j]+" ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
