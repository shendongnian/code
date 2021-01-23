    private static readonly object doSomethingLock = new object();
    public static void DoSomething (SomeObject o) 
    {
       var sameObject = doSomethingLock;
       lock(sameObject) 
       {
           o.Update();
           // etc....
       }
    }
