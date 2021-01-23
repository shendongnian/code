    public class DbSomething : IDisposable{
        private SqlConnection _connection;
        public DbSomething (){
           _connection = new SqlConnection();
        }
        public void Dispose(){
         _connection.Dispose();
        }    
    }
