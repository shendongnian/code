    static void Main(string[] args)
    {
        int rows = 3, cols = 5;
        int tCount = 2, nn = 3;
        float[,] dataset2D = { { 1.0f,      1.0f,       1.0f,       2.0f,       3.0f},
                               { 10.0f,     10.0f,      10.0f,      3.0f,       2.0f},
                               { 100.0f,    100.0f,     2.0f,       30.0f,      1.0f} };
        float[,] testset2D = { { 1.0f,      1.0f,       1.0f,       1.0f,       1.0f},
                               { 90.0f,     90.0f,      10.0f,      10.0f,      1.0f} };
        var fparams = new FlannParameters();
        var index = NativeMethods.flannBuildIndex(dataset2D, rows, cols, out float speedup, ref fparams);
        var indices = new int[tCount, nn];
        var idists = new float[tCount, nn];
        NativeMethods.flannFindNearestNeighborsIndex(index, testset2D, tCount, indices, idists, nn, ref fparams);
        NativeMethods.flannFreeIndex(index, ref fparams);
    }
    [DllImport(DllWin32, EntryPoint = "flann_build_index", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr flannBuildIndex(float[,] dataset,
                                                int rows, int cols,
                                                out float speedup, // out because, it's and output parameter, but ref is not a problem
                                                ref FlannParameters flannParams);
    [DllImport(DllWin32, EntryPoint = "flann_free_index", CallingConvention = CallingConvention.Cdecl)]
    public static extern int flannFreeIndex(IntPtr indexPtr,  ref FlannParameters flannParams);
    [DllImport(DllWin32, EntryPoint = "flann_find_nearest_neighbors_index", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
    public static extern int flannFindNearestNeighborsIndex(IntPtr indexPtr,
                                                            float[,] testset,
                                                            int tCount,
                                                            [In, Out] int[,] result, // out because it may be changed by C side
                                                            [In, Out] float[,] dists,// out because it may be changed by C side
                                                            int nn,
                                                            ref FlannParameters flannParams);
    [StructLayout(LayoutKind.Sequential)]
    public struct FlannParameters
    {
        public FlannAlgorithmEnum algorithm;
        public int checks;
        public float eps;
        public int sorted;
        public int maxNeighbors;
        public int cores;
        public int trees;
        public int leafMaxSize;
        public int branching;
        public int iterations;
        public FlannCentersInitEnum centersInit;
        public float cbIndex;
        public float targetPrecision;
        public float buildWeight;
        public float memoryWeight;
        public float sampleFraction;
        public int tableNumber;
        public int keySize;
        public int multiProbeLevel;
        public FlannLogLevelEnum logLevel;
        public int randomSeed;
    }
