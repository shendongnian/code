    private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    StringBuilder str = new StringBuilder("server=");
                    str.Append(textBox1.Text);
                    str.Append(";database=");
                    str.Append(textBox2.Text);
                    str.Append(";UID=");
                    str.Append(textBox3.Text);
                    str.Append(";password=");
                    str.Append(textBox4.Text);
    
                    updateConfigFile(str);
    
                    SqlConnection con = new SqlConnection();
        
                    //Refresh Connection String each time else
                    //it will use previous connection string.
                    ConfigurationManager.RefreshSection("connectionStrings");
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
                    //Check the new connection string is working or not
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from egtab3");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Connected Sucessfully");
                    con.Close();
        
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
