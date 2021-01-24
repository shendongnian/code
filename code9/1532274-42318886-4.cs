    // Please note that it's a VERY hypothetical example, don't take
    // it as an actual advise on how to implement a data mapper!!
    public class DataMapper
    {
         public DataMapper(ApplicationConfiguration appConfig)
         {
               AppConfig = appConfig;
         }
    
         public ApplicationConfiguration AppConfig { get; }
         private IDbConnection Connection { get; }
    
         public void Connect()
         {
               // We access the configured connection string
               // from the application configuration object
               Connection = new SqlConnection(AppConfig.Database.ConnectionString);
               Connection.Open();
         }
    }
