    using (SqlConnection con = new SqlConnection(someconnectionstring)) {
        using (SqlCommand cmd = new SqlCommand("myStoredProc", con)) {
          cmd.CommandType = CommandType.StoredProcedure;
          //If you have parameters in your SP, add like this else ignore below line
          cmd.Parameters.Add("@myparam", SqlDbType.VarChar).Value = somevalue;
              
          con.Open();
          cmd.ExecuteNonQuery();
        }
      }
