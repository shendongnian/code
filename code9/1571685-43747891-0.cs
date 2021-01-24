    String GetConnectionString()
    {
       // Get the connection string info from Connection Strings (App Service) 
       // with automatic graceful fallback to web.config
       string cs = WebConfigurationManager.ConnectionStrings["db"].ConnectionString;
    
       if (cs == null)
          throw new Exception("Could not locate DB connection string");
    
       return cs;
    }
