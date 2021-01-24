    using System.Data.SqlClient;
    static void Main(string[] args)
        {
          var server = ".";
          var database = "tester";
    
          var connection = $"Server ={server};Database={database};Trusted_Connection=True;";
    
          using (SqlConnection cn = new SqlConnection(connection))
          using (SqlCommand cmd = new SqlCommand("exec ErrorThrower", cn))
          {
            cn.Open();
            //handles ONLY SQL Exceptions
            try
            {
              cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlException)
            {
              //Do what you want in your program with the failure of SQL.  I am just echoing it for example purposes, I could log it or do more with it.
              Console.WriteLine(sqlException.Message);
            }
    
            cn.Close();
          }
    
          Console.ReadLine();
        }
