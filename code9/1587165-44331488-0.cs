    private string connectionString = 
    System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    
    .
    .
    .
    using (TEMPDataContext dbContext = new TEMPDataContext(connectionString))
    {
         ....
    }
