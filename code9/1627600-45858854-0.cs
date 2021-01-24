    try
    {
         someService.DoSomething(sessionId)
    }
    catch(Exception ex)
    {
      if (ex.Message.Contains("Houston"))
      {
          //this indicates that someService couldn't connect to the database
      }
      else if(ex.Message.Contains("is on fire"))
      {
          //someService detected that the network is exploded
      }
      else{
      //we can only handle the two previous cases, all else is passed on}
      throw;       
    }
