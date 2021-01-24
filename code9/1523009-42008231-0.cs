    using (SqlConnection conn = new SqlConnection())
    {
      using (SqlCommand cmd = new SqlCommand("SelectAllPhones", conn))
      {
        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OS", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = phoneOS });
        cmd.CommandType = CommandType.StoredProcedure;
        
        SqlDataReader reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
          // load your data...
                                
        }
        
      }
    }
