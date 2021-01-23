    try
    {
       //...
       _sem.Wait();
       try
       {
           //do work
       }
       finally
       {
           _sem.Release(); //called, even if there's an exception
       }
    }
    catch (Exception)
    {
        //...
        //this is just sloppy. never ignore ALL exceptions
        //fix this.
        break; 
    }
