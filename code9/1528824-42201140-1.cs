    myEvent+=myEvent_handler
    
    void myEvent_handler()
    {
      try
      {
         MyMethod1();
      }
      catch (Exception ex)
      {
         //handle it
      }
      try
      {
         MyMethod2();
      }
      catch (Exception ex)
      {
        //handle it
      }
