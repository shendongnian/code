    private async void button2_Click(object sender, EventArgs e) {
     //Hash
     var hash = SecurePasswordHasher.Hash("password");
    
     //Verify
     var result = SecurePasswordHasher.Verify("password", hash);
    
     if (
      txtUsername.Text == "" || txt_Password.Text == "") {
      MessageBox.Show("Please provide a Username and Password");
      return;
     }
    
     try {
      //Create SqlConnection
      SqlConnection con = new SqlConnection(cs);
      SqlCommand cmd = new SqlCommand("Select * from [break].[dbo].[tabl_login] where UserName=@username and Password=@password", con);
      cmd.Parameters.AddWithValue("@username", txtUsername.Text);
      cmd.Parameters.AddWithValue("@password", txt_Password.Text);
      con.Open();
      SqlDataAdapter adapt = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapt.Fill(ds);
      con.Close();
      int count = ds.Tables[0].Rows.Count;
      //If count is equal to 1, than show frmMain form
      if (count == 1) {
       MessageBox.Show("Login Successful!");
       await CheckForUpdates();
      } else {
       MessageBox.Show("Login Failed!");
      }
     } catch (Exception ex) {
      MessageBox.Show(ex.Message);
     }
    }
