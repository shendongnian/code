      public class BaseRepository 
      {
         public static string ConnectionString { get; set; }
    
         static BaseRepository ()
         {
                ConnectionString = ConfigurationManager.AppSettings["dbConn"];
         }
      }
