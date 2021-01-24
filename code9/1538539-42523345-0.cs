    private void button1_Click_1(object sender, EventArgs e)
    {
        try
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-P3JSE1C;Initial Catalog=logins;Integrated Security=True");
            connection.Open();
            SqlCommand checker = new SqlCommand("SELECT COUNT (*) from users WHERE username=@userName AND pssword = @password", connection);
            checker.Parameters.Add(new SqlParameter("@userName", textBox1.Text));
            checker.Parameters.Add(new SqlParameter("@password", textBox3.Text));
            var count = Convert.ToInt32(checker.ExecuteScalar());
            connection.Close();
            if(count > 0)
            {
               main wen = new main();
               wen.Show();
            }
            else
            {
                MessageBox.Show("Incorrect password or username.");
            }
        }
        catch
        {
            MessageBox.Show("Incorrect password or username.");
        }
    } 
