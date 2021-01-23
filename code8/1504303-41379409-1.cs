    void GetUsername(string Username)
    { 
      SqlConnection con = new SqlConnection("Data Source=METHOUN-PC;Initial Catalog=ITReportDb;Integrated Security=True");
      SqlCommand cmd = new SqlCommand("Select UserName from tblLogin where UserId='" + Username + "'", con);
      con.Open();
       TextBox1.Text = (cmd.ExecuteScalar() ?? "").ToString(); //If it is null it will return an empty string
       rdr.Close();
       con.Close();
    }
