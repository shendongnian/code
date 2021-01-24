    static void Main(string[] args)
    {
        for (int i = 0; i < 1000 * 1000; i++)
        {
            //  The scope of j is limited to the loop block.
            //  For each new iteration, there is a new j. 
            var j = i;
            Task.Run(() => WriteHelloAsync(j));
        }
    
        Console.ReadLine();
    }
