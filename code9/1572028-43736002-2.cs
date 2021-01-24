    public static bool checkConnectionString(string con)
    {
	if(ConfigurationManager.ConnectionStrings[con] !=null)
	{
      if (Convert.Tostring( ConfigurationManager.ConnectionStrings[con].ConnectionString) == "" && !checkConnectionStringValidity(con)
	  { 
		return false;
	  }
	  else
	  {
		 return true;
	  }
	}
	else 
	{
		 return false;
	}
    }
