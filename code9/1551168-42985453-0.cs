    using (SqlConnection con = new SqlConnection(_connectionstring))
    {
      con.Open();
      string sqlQuery = "SELECT TOP 1 tuition_fee FROM Tuition WHERE     
      tuition_code = @tuitionCode";
      SqlCommand cmd = new SqlCommand(sqlQuery, con);
      cmd.Parameters.AddWithValue("@tuitionCode", studenttuition_code);
      SqlDataReader dr = cmd.ExecuteReader();
      while (dr.Read())
      {
        lblAmount.Text = dr["tuition_fee"].ToString();
      }
      con.Close(); 
    }
