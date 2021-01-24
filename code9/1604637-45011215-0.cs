    private void DoSomething()
    {
        using (var file = File.Create(@"D:\test.txt"))
        {
            for (int i = 0; i < 100000; i++)
            {
            }
        };
            
        File.Delete(@"D:\test.txt");
    }
