    var host = System.Configuration.ConfigurationManager.AppSettings["dbHostAddress"]
    
    var connectionString = System.Configuration.ConfigurationManager.
       ConnectionStrings["ConnectionString"]
      .ConnectionString.Replace("REPLACE_VALUE",host);
