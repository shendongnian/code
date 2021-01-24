    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection cn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from account where user=@username", cn);
            cmd.Parameters.AddWithValue("@username", textBox2.Text);
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cn.Close();
            if (ds.Tables[0].Rows.Count == 1)
            {
                // A user with this username exists, check the password.
                if (ds.Tables[0].Rows[0][1] == textBox1.Text)
                {
                    // The login succeeded, show Form2.
                    Form2.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Login please check username and password");
                }
            }
            else
            {
                // No user with the given username exists.
                MessageBox.Show("Invalid Login please check username and password");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
