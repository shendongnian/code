    using (SqlConnection cn = new SqlConnection(ConnectionString))
    {
         query = "SELECT * FROM [MyTable]";
    
         using (SqlCommand commandUserPortal = new SqlCommand(query, cn))
         {
             cn.Open();
         }
      }
