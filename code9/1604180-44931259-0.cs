    public static Task SlowOutput(BlockingCollection<string> output)
    {
        return Task.Run(() =>
        {
            for(var i = 0; i < int.MaxValue; i++)
            {
                output.Add(i);
                System.Threading.Thread.Sleep(1000);
            }
            output.Complete​Adding();
        }
    }
