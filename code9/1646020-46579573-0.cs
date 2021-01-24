     using (SqlConnection cn = new SqlConnection(connectionStr))
    {
      string sql1 = "insert into sampdb values(@name,@phone);"+ "Select Scope_Identity()";
      using (SqlCommand cmd = new SqlCommand(sql1, cn))
      {
        cmd.Parameters.AddWithValue("@name", TextBox1.Text);
        cmd.Parameters.AddWithValue("@phone", TextBox2.Text);
        cn.Open();
        ID =  cmd.ExecuteNonQuery();
      }
      //ID = Convert.ToInt32(cmd.ExecuteScalar());
      cn.Close();
      TextBox1.Text = "";
      TextBox2.Text = "";
      string sql2 = "insert into sampfk values (@userid, @address, @emailid)";
      using (SqlCommand cmd = new SqlCommand(sql2, cn))
      {
        cmd.Parameters.AddWithValue("@userid", ID);
        cmd.Parameters.AddWithValue("@emailid", TextBox3.Text);
        cmd.Parameters.AddWithValue("@address", TextBox4.Text);
        cn.Open();
        cmd.ExecuteNonQuery();
      }
      con.Dispose();
      con.Close();
    }
