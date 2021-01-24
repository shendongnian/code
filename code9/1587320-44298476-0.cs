    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter SDA = new MySqlDataAdapter("SELECT * WHERE 'wa' SOUNDS LIKE @a", con);
            SDA.SelectCommand.Parameters.AddWithValue("@a", textBox1.Text);
                SDA.Fill(dt);
            dataGridView1.DataSource = dt;
        } catch (MySqlException ex)
        {
            Console.WriteLine("Stacktrace: \n" + ex.StackTrace);
            MessageBox.Show("Mysql error", "Mysql based error!");
        }
    }
