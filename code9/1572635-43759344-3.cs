    try
    {
        // Put your connection into a using block to have closing/disposing handled for you
        using (con = new SqlConnection(cs.DBConn))
        {
            con.Open();
            // Create a query with placeholders for your parameter values
            // Limit it with TOP 1 - since you only expect to identify 1 user
            string sql = "SELECT TOP 1 [Image] FROM [Users] WHERE [Username] = @usr AND [password] = @pwd";
            using (cmd = new SqlCommand(sql, con))
            {
                // add a parameter with the user name value
                cmd.Parameters.AddWithValue("usr", TxtUserName.Text);
                // add a parameter with the password value
                cmd.Parameters.AddWithValue("pwd", TxtPassword.Text);
                // Use ExecuteScalar since you only expect 1 row with 1 column
                byte[] b = cmd.ExecuteScalar() as byte[];
                // you may want to check if byte array b is null
                // Same as for Connection: let using handle disposing your MemoryStream
                using (MemoryStream ms = new MemoryStream(b))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                    frm.pictureBox2.Image = pictureBox1.Image;
                }
            }
        }
    }
    catch (Exception ex)
    { 
        MessageBox.Show(ex.Message);
    }
