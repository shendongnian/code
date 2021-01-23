    struct Point { int x; int y; }
    class Program
    {
        const int Size = 100000;
        private static void Main(string[] args)
        {
            object[] array = new object[Size];
            long initialMemory = GC.GetTotalMemory(true);
            for (int i = 0; i < Size; i++)
            {
                array[i] = new Point[3];
            }
            long finalMemory = GC.GetTotalMemory(true);
            GC.KeepAlive(array);
            long total = finalMemory - initialMemory;
            Console.WriteLine("Size of each element: {0:0.000} bytes",
                              ((double)total) / Size);
        }
    }
