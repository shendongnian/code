    using System.Data.SqlClient;
    static void Main(string[] args)
        {
          var server = ".";
          var database = "tester";
    
          var connection = $"Server ={server};Database={database};Trusted_Connection=True;";
    
          var listOfErrors = new List<SqlError>();
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
              foreach(SqlError error in sqlException.Errors)
              {
                 listOfErrors.Add(error);
              }
              Console.WriteLine($"There were {listOfErrors.Count} errors executing");
              listOfErrors.ForEach(x => Console.WriteLine($"\tError was {x.Message}"));
            }
    
            cn.Close();
          }
    
          Console.ReadLine();
        }
