    public class DbSomething : IDisposable{
        private SqlConnection _connection;
        public DbSomething (SqlConnection connection){
           _connection = connection;
        }
        public void Dispose(){
         _connection.Dispose();
        }    
    }
