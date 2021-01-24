    using (SqlConnection con = new SqlConnection(dc.Con)) {
        using (SqlCommand cmd = new SqlCommand("insert into sms values(@usecase,@smsbody,GETDATE())", con)) {
          cmd.CommandType = CommandType.StoredProcedure;
    
          cmd.Parameters.Add("@usecase", SqlDbType.VarChar).Value = usecase;
          cmd.Parameters.Add("@smsbody", SqlDbType.VarChar).Value = smsbody;
    
          con.Open();
          cmd.ExecuteNonQuery();
        }
      }
