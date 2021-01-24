    using (SqlConnection con = new SqlConnection(dc.Con)) {
        using (SqlCommand cmd = new SqlCommand("ADDTrack", con)) {
          cmd.CommandType = CommandType.StoredProcedure;    
          cmd.Parameters.Add("@Titel", SqlDbType.VarChar).Value = textBoxTitel.Text;
          
    
          con.Open();
          cmd.ExecuteNonQuery();
        }
      }
