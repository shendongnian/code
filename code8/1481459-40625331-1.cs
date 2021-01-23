    public static int[,] Ctable;
    private static void GetTable(int m, int n)
    {
        Ctable = new int[m, n]; // Initialize array here.
        for (int i = 0; i < m; i++) // Iterate i < m not i <= m.
        {
            Ctable[i, 0] = 1;
        }
    }
