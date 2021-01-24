    static Queue<Action> myQ = new Queue<Action>();
    static void Main(string[] args)
    { 
        myQ.Enqueue(() =>
        {
            TestQ("First");
        });
        myQ.Enqueue(() =>
        {
            TestQ("Second");
        });
        Thread thread = new Thread(() =>
        {                             
            while(true) {
                Thread.Sleep(5000)
                if (myQ.Count > 0) {
                    myQ.Dequeue().Invoke()
                }
            }
        }).Start();
        // Do other stuff, eventually calling "thread.Stop()" the stop the infinite loop.
        Console.ReadLine();
    }
    private static void TestQ(string s)
    {
        Console.WriteLine(s);
    }
