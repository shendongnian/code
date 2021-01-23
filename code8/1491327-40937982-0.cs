    public void DoWork(Action completeCallback)
    {
        ... //Do Stuff
        completeCallback();
    }
    
    public void FirstMainMethod()
    {
         DoWork(() => Console.WriteLine("First callback");
    }
    
    public void SecondMainMethod()
    {
         DoWork(() => Console.WriteLine("Second callback");
    }
