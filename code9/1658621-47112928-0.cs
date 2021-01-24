    static void Main(string[] args)
    {
        Console.WriteLine(GetString());
    
        Console.ReadLine();
    }
    
    private static async Task TimeConsumingTask()
    {
        await Task.Run(() => System.Threading.Thread.Sleep(100));
    }
    
    private static string GetString()
    {
        string s = "I am empty";
        TimeConsumingTask().ContinueWith(t =>
        {
            s = "GetString was called";
        });
    
        return s;
    }
