    public static async Task Do(Int32 count)
    {
        //I tried 'await Task.Yield()' here; didn't help.
    
        //consume memory
        for (Int32 i = 0; i < count; i++)
        {
            Console.Write(Guid.NewGuid().ToString());
        }
        //do I/O
        await Task.Delay(10000);
    }
