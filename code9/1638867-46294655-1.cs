    [ThreadStatic]
    private static bool someFlag;
    
    var thread = new Thread(GetContext);
    thread.Start()
    
    public Context GetContext()
    {
       someFlag = true;
       //...
       if(someFlag == true)
          //do some thing...
       else
          //do some thing...
    }
