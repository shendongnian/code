public class DALConnection 
{
      public DALConnection(string _conString)
      {
            if(!String.IsNullOrEmpty(_conString))
            {
                con=new SqlConnection(_conString);
            }
            else 
            {
                //error handling
            }
      }      
          
      private SqlConnection con;
}
public class DataAccessOperation: DALConnection 
{
      public DataAccessOperation (string _conString) :base (_conString)
      {
      }
    
}
