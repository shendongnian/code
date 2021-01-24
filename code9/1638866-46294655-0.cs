    [ThreadStatic]
    private static bool someFlag;
    
    var thread = new Thread(GetContext);
    thread.Start()
    
    public Context GetContext()
    {
       someFlag = true;
       //...
       if(thread.SomeFlag == True)
          //do some thing...
       else
          //do some thing...
    }
