    public interface IDatabase{
    
    IDbConnection GetConnection();
    IEnumerable<T> Query<T>(whatever you want here...exactly Dapper's parameters if necessary);
    
    }
    
    public class Database : IDatabase{
         //implement GetConnection() however you like...open it too!
         public IEnumerable<T> Query<T>(...parameters...){
    
         IEnumerable<T> query = null;
         using(conn = this.GetConnection()){
              query = conn.Query<T>()//dapper's implementation
         }
         return query;
       }
    }
