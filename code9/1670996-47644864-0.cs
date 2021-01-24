    public static bool Even(int i)
    {
        return num % 2 == 0;  //true: even, false: odd
    }
    public static void ThreadSafe()
    {
        bool[] arr = new bool[333];
        Parallel.For(0, arr.Length, index =>
        {
            arr[index] = Even(index);
        });
    }
