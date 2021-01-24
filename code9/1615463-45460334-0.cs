    Task.Factory.StartNew(() =>
    {
      MyRCWType objServer = null;
      try
      {
        objServer = new MyRCWType(); // create COM wrapper object
        objServer.MyMethodCall1();
        objServer.MyMethodCall2();
      }
      catch(Exception ex)
      {
        // Handle exception
      }
      finally
      {
        if(objServer != null)
        {
          while(Marshal.ReleaseComObject(objDA) > 0); // dispose COM wrapper object
        }
      }
    });
