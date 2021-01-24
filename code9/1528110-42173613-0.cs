    int[][] m = new int[][] {
        new int[] { 1, 2, 3, 4 },
        new int[] { 0, 1, 4, 3 },
        new int[] { 4, 0, 2, 2 },
        new int[] { 4, 2, 0, 1 }};
    int max = m.Length;
    for (int i = -max+1; Math.Abs(i) < max; i++)
    {
        for (int j = 0; j <= max - Math.Abs(i) - 1; j++)
        {
            int row = i < 0 ? j : i + j;
            int col = i > 0 ? j : (Math.Abs(i) + j);
            Console.Write(m[row][col]);
        }
        Console.WriteLine();
    }
