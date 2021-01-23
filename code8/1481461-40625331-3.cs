    private const int M = 16; // Size of the array element at 0.
    private const int N = 3; // Size of the array element at 1.
    public static int[,] Ctable = new int [M, N]; // Initialize array.
    private static void GetTable(int n)
    {
        for (int i = 0; i < M; i++)
        {
            Ctable[i, 0] = 1;
        }
    }
