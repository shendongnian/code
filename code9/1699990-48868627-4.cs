    public unsafe static void Main()
    {
        var data = new uint[1][];
        data[0] = new uint[100000];
        data[0][0] = 1;
        data[0][1] = 2;
        data[0][2] = 3;
        Stopwatch sw = new Stopwatch();
        sw.Start();
        foreach (uint[] LogRow in data)
        {
            fixed (uint* start = &LogRow[0])
            {
                var dataLength = LogRow.Length * sizeof(uint);
                byte[] result = new byte[dataLength];
                
                Marshal.Copy((IntPtr)start, result, 0, dataLength);
                // This will return 100020003000...00000......
                // Do something with result
            }
        }
        sw.Stop();
        Console.WriteLine(sw.ElapsedTicks);
        Console.ReadKey();
    }
