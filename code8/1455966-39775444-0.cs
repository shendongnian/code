    public bool IsDatabaseOrWeb
    {
       get
       {
          return (ServerType == ServerType.Web || ServerType == ServerType.Database);
       }
    }
