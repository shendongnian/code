    connectionString = ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString;
                con.ConnectionString = connectionString;
                string Comparing="N";
    
                string query = "select Status from Registration where Status='N'";
                con.Open();
                OleDbCommand cmd = new OleDbCommand(query, con);
                string compare = Convert.ToString(cmd.ExecuteScalar());
                con.Close();
                if (compare == Comparing)
                {
                    this.Hide();
    
                    Login_Page lp = new Login_Page();
                    lp.Show();
    
                }
                else 
    {
    MessageBox.Show("Pls Register yourself");
    
    }
