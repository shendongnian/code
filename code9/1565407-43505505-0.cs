    string dbStatus = string.Empty;
    try
    {
      //Connecting to DB;
      dbStatus = "Up";
    }
    catch
    {
    dbStatus = "Down";
    //log the exception
    }
