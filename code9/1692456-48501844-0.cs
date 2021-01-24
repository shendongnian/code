    private string _connectionString = @"Database= app2000; Data Source = localhost; User = root; Password =''";
    using (var con = new MySqlConnection(_connectionString))
    {
        i = 0;
        con.Open();
        MySqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT * FROM adminlogin WHERE username='" + txtBoxUsername + "'AND password='" +
                            txtBoxPassword + "'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        da.Fill(dt);
        i = Convert.ToInt32(dt.Rows.Count.ToString());
        if (i == 0)
        {
            lblerrorInput.Show();
        }
        else
        {
            this.Hide();
            Main ss = new Main();
            ss.Show();
        }
        con.Close(); // Close the connection
    }
