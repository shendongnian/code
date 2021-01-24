    using (var con = new SqlConnection(_connectionstring))
    {
       con.Open();
       string sqlQuery = "SELECT tuition_fee FROM Tuition WHERE tuition_code = @tuitionCode";
       var cmd = new SqlCommand(sqlQuery, con);
       cmd.Parameters.AddWithValue("@tuitionCode", studenttuition_code);
       var dr = cmd.ExecuteReader();
       while (dr.Read())
       {
         lblAmount.Text = dr.GetValue; 
       }
       con.Close(); 
    }
