    try
       {
       using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString()))
            {
             conn.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT * from tb_useraccounts;", conn);
        MySqlDataReader dr = cmd.ExecuteReader();
         while (dr.Read())
         {
            if (UserName == (dr["username"].ToString()) && PassWord == (dr["password"].ToString()))
                        {
                            frmMain main = new frmMain();
                            main.Show();
                            login.Hide();
                        }
                        else if (UserName == string.Empty || PassWord == string.Empty)
                        {
                            MessageBox.Show("Please fill the blank spaces!");
                        }
                        else
                        {
                            MessageBox.Show("The username and password you inserted is incorrect!");
                        }
                    }
                        dr.Close();
                        conn.Close();
                }
 
