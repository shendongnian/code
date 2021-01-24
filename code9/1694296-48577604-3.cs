    protected void Add_Click(object sender, EventArgs e)
    {
      string constr = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
      try {
        using (SqlConnection con = new SqlConnection(constr))
          using (SqlCommand cmd = new SqlCommand("insert into Student(RegNo,Name,Address,CreatedTime)values(@RegNo,@Name,@Address,Getdate())", con)) {
            cmd.Parameters.AddWithValue("@RegNo", RegNo.Text);
            cmd.Parameters.AddWithValue("@Name", Name.Text);
            cmd.Parameters.AddWithValue("@Address", Address.Text);
            con.Open();
            cmd.ExecuteNonQuery();
          }
      } catch (Exception ex) {
        //handle exception..
        throw;
      }
    }
