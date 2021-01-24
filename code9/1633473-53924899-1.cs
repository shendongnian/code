    public class AppSettings
    {
       public bool UseInMemory { get; set; }
    
       public string Server { get; set; }
       public string Port { get; set; }
       public string Database { get; set; }
       public string User { get; set; }
       public string Password { get; set; }
    
       public string BuildConnectionString()
       {
    	   if(UseInMemory) return null;
    	   
    	   // You can set environment variable name which stores your real value, or use as value if not configured as environment variable
    	   var server = Environment.GetEnvironmentVariable(Host) ?? Host;
    	   var port = Environment.GetEnvironmentVariable(Port) ?? Port;
    	   var database = Environment.GetEnvironmentVariable(Database) ?? Database;
    	   var user = Environment.GetEnvironmentVariable(User) ?? User;
    	   var password = Environment.GetEnvironmentVariable(Password) ?? Password;
    	   
    	   var connectionString = $"Server={server};Port={port};Database={database};Uid={user};Pwd={password}";
    	   
    	   return connectionString;
       }
    }
