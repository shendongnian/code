    using (SqlConnection cn = new SqlConnection(ConnectionString))
    {
         query = "SELECT * FROM [MyTable]";
         cn.Open();
         using (SqlCommand commandUserPortal = new SqlCommand(query, cn))
         {
             
         }
      }
