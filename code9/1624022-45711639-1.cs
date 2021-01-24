    private static void Main(string[] args)
    {
        FileStream file1 = File.Create(@"D:\test\plik1.dat");
        FileStream file2 = File.Create(@"D:\test\plik1.dat");
    
        var f1 = write(file1);
        var f2 = write(file2);
        for (int i = 0; i < 1024 * 1024; i++)
        {
            if (i % 100 == 0)
                Console.Write("X");
        }
        Task.WaitAll(f1,f2);
    }
    
    private static async Task write(FileStream fs)
    {
        var zap = new StreamWriter(fs);
        for (long i = 0; i < 1024 * 1024 * 250; i++)
        {
            await zap.WriteAsync("xxx");
        }
    }
