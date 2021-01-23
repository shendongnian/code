    public class MonitorClass
    {
       private string connStr;
    
       public MonitorClass(string connectionString) 
       {
          this.connStr = connectionString;
       }
    
       public void Run()
       {
           using (MySqlConnection conn = new MySqlConnection(connStr))
           using (MySqlCommand cmd = conn.CreateCommand())
           {
               conn.Open();
               ...
           }
       }
    }
