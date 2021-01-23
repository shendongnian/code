    private const int M = 16; // Size of the array element at 0.
    private const int N = 3; // Size of the array element at 1.
    public static int[,] Ctable = new int [M, N]; // Initialize array with the size of 16 x 3.
    private static void GetTable()
    {
        for (int i = 0; i < M; i++)
        {
            Ctable[i, 0] = 1;
        }
    }
