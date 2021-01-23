    public class MonitorClass
    {
       private readonly string _connStr;
    
       public MonitorClass(string connectionString) 
       {
          this._connStr = connectionString;
       }
    
       public void Run()
       {
           using (MySqlConnection conn = new MySqlConnection(_connStr))
           using (MySqlCommand cmd = conn.CreateCommand())
           {
               conn.Open();
               ...
           }
       }
    }
