    private static void Main(string[] args)
    {
        FileStream file1 = File.Create(@"D:\test\plik1.dat");
        FileStream file2 = File.Create(@"D:\test\plik2.dat");
    
        var f1 = Write(file1);
        var f2 = Write(file2);
        var work = DoWork();
        Task.WaitAll(f1,f2,work);
    }
    
    private static async Task DoWork()
    {
        for (int i = 0; i < 1024 * 1024; i++)
        {
            if (i % 100 == 0)
                Console.Write("X");
        }
    }
    private static async Task Write(FileStream fs)
    {
        var zap = new StreamWriter(fs);
        for (long i = 0; i < 1024 * 1024 * 250; i++)
        {
            await zap.WriteAsync("xxx");
        }
    }
