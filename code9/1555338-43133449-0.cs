     public class ExampleDBContext : DbContext
        {
        public ExampleDBContext(string nameOrConnectionString) : 
           base(nameOrConnectionString)
        {
        }
    }
