    using (var con = new SqlConnection("ConnectionString"))
    {
      con.Open();
      string query = "SELECT COUNT(*) FROM Some_Table WHERE Val > 5";
      using (var cmd = new SqlCommand(query, con))
      {
          int rowsAmount = cmd.ExecuteScalar(); // get the value of the count
          if (count > 0) 
          {
              Console.WriteLine("Returned more than 0 rows");
          }
          else
          {
              Console.WriteLine("Did not return more than 0 rows");
          }
          Console.ReadLine();
    }
