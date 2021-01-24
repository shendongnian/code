    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    sw.Start();
    for (int i = 0; i < 1000; i++)
    {
       string s = RandomString(10000);
    }
    sw.Stop();
    Console.WriteLine(sw.Elapsed.TotalMilliseconds);
    sw.Restart();
    
    for (int i = 0; i < 1000; i++)
    {
        string s = GetRandomString(10000);
    }
    
    sw.Stop();
    Console.WriteLine(sw.Elapsed.TotalMilliseconds);
    Console.Read();
