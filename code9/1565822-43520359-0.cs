    public string GetDBStatus(string connectionString)
    {
     string status = string.Empty;
    try
    {
      //connecting to your DB
      status = "Up";
    }
    catch(Exception ex)
    {
      status = "Down";
      //log error to somewhere
    }
    return status;
    }
