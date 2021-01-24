    private void CoreInsert() {
      //Done: wrap IDisposable into using, do not close explicitly
      //TODO: do not hardcode strConnection, but read from settings
      using (SqlConnection con = new SqlConnection(strConnection)) {
        con.Open();
    
        // Make sql 
        //   1. Readable: can you see a problem with "Number" now? 
        //   2. Parametrized 
        string sql = 
          @"insert into user(
              uname, 
              address, 
              email, 
              [number]) -- <- number is MS SQL's reserved word, put it as [number]
            values(
              @prm_uname, 
              @prm_address, 
              @prm_email, 
              @prm_number)";
    
        //Done: wrap IDisposable into using
        using (SqlCommand cmd = new SqlCommand(sql, con)) {
          cmd.Parameters.AddWithValue("@prm_uname", TextBox1.Text);
          cmd.Parameters.AddWithValue("@prm_address", TextBox2.Text);
          cmd.Parameters.AddWithValue("@prm_email", TextBox3.Text);
          //TODO: check actual field's type here 
          cmd.Parameters.AddWithValue("@prm_number", TextBox4.Text);
    
          cmd.ExecuteNonQuery();
        }    
      }
    }
