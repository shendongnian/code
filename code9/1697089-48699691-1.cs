    public static void Main(string[] args)
    {
        while(!Debugger.IsAttached)
        {
            Thread.Sleep(1000); //Sleep 1 seconds and check again.
        }
    
        //Rest of your code  
    }
