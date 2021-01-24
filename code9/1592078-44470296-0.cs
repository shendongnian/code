    string con = ConfigurationManager.ConnectionStrings["BAEntities"].ConnectionString;
    Type contextType = typeof(BAEntities);
    string efConnection = 
        string.Format(
            "metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl;provider=System.Data.SqlClient;provider connection string=\"{1}\"",
            contextType.Name,
            con);
    
    object objContext = Activator.CreateInstance(contextType, efConnection);
    return objContext as Entities; 
