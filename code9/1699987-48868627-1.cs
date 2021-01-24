    public unsafe static void Main()
    {
        var data = new uint[1][];
        data[0] = new uint[100000];
        data[0][0] = 0;
        data[0][1] = 1;
        data[0][2] = 2;
        Stopwatch sw = new Stopwatch();
        sw.Start();
        foreach (uint[] LogRow in data)
        {
            fixed (uint* start = &LogRow[0])
            {
                byte* foo = (byte*)start;
                var dataLength = LogRow.Length * sizeof(uint);
                byte[] result = new byte[dataLength];
                
                Marshal.Copy((IntPtr)foo, result, 0, dataLength);
                // Do something with result
            }
        }
        sw.Stop();
        Console.WriteLine(sw.ElapsedTicks);
        Console.ReadKey();
    }
