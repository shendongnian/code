    string constring = ConfigurationManager.ConnectionStrings["The_patients.Properties.Settings.Users1ConnectionString"].ConnectionString;
    using(OleDbConnection con = new OleDbConnection(constring))
    {
        string q = @"select * from Users  
                     where UserName = @Username and [Password] = @Password ";
        using(OleDbCommand cmd = new OleDbCommand(q, con))
        {
            cmd.Parameters.AddWithValue("@Username", this.UserName.Text);
            cmd.Parameters.AddWithValue("@Password", this.Password.Text);
            con.Open();
            using(OleDbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows == true)
                   MessageBox.Show("Login Successfully Done");
                else
                   MessageBox.Show("Access Denied, password username mismatched"); 
            }
        }
    }
