    public class DALConnection {
    
         public SqlConnection con;
    
         public DALConnection(string connectionString)
         {
              con = new SqlConnection(connectionString);
         }
    
    }
