    public class DbSomething : IDisposable
    {
        public SqlConnection Connection;
        public DbSomething (){
           Connection = new SqlConnection();
        }
       //same dispose  
    }
