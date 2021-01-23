    try
    {
      using (SqlCommand cmd = new SqlCommand())
      {
           cmd.Connection = conn;
           ...
           rowsInserted = rowsInserted + cmd.ExecuteNonQuery();
           // Call dispose is not needed
      }
    }
