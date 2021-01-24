    public class MyConfiguration : DbConfiguration 
    { 
        public MyConfiguration() 
        { 
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy()); 
        } 
    }
    public class MyConfiguration : DbConfiguration 
    { 
        public MyConfiguration() 
        { 
            SetExecutionStrategy( 
                "System.Data.SqlClient", 
                () => new SqlAzureExecutionStrategy(1, TimeSpan.FromSeconds(30))); 
        } 
    }
