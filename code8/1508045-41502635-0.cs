    public bool doLoop = true;
    public bool doProcess = true;
    
    public void MyLoop()
    {
       while(doLoop)
       {
          while(doProcess)
          {
             // do some stuff
             if (condition)
             {
                doProcess = false;
             }
          }
        }
    }
