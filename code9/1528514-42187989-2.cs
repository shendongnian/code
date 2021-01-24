    try
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\LOUI;InitialCatalog=login_db;User ID=sa;Password=1029384756");//problem is here
        SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From login where name = '" + User_txt.Text + "'and pass = '" + Pass_txt.Text + "'", con); 
        DataTable dt = new DataTable();
        sda.Fill(dt); 
        if (dt.Rows[0][0].ToString() == "1")
        {
            this.Hide();
            adminpanel ap = new adminpanel();
            ap.Show();
        }
        else
        {
            MessageBox.Show("Check Username or Password");
        }
    }
    catch (Exception z)
    {
       MessageBox.Show("Connection error");
    }
