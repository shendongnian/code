    using System.Threading;
    static void Main(string[] args)
    {
        bool breakConditionFlag = false;
        ManualResetEvent waitHandler = new ManualResetEvent(false); 
    
        while(breakConditionFlag)
        {
    
        //Your Code
    
        waitHandler.WaitOne(TimeSpan.FromMilliSeconds(1000)); // 1000 is the Arbitary value you can change it to Suit your purpose;
    
        }
    }
