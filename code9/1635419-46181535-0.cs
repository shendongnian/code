    public class MyModel : DbContext
    {
        public MyModel () 
          : base(ApplicationParameters.ConnectionStringName)
        {
        }
    
        public MyModel (string connectionStringName)
          : base(connectionStringName)
        {
        }
    
    }
