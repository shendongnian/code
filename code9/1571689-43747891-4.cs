    String GetConnectionString()
    {
       // Get the Connection String from Application Settings (App Service) 
       // with graceful fallback to web.config
       string cs = WebConfigurationManager.ConnectionStrings["db"].ConnectionString;
    
       if (cs == null)
          throw new Exception("Could not locate DB connection string");
    
       return cs;
    }
