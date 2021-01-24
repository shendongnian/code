    private void button1_Click(object sender, EventArgs e)
    {
        int stNo;
        if (!int.TryParse(textBox1.Text, out stNo))
        {
            // not a number
            return;
        }
        // It is a number so do the rest 
        sqlConnection1.Close();
        SqlCommand cmd;
        dataSet41.Clear();
        cmd = new SqlCommand("stSelect", sqlConnection1);
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@stNo", stNo); //<-- number is expected
        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
        sqlDataAdapter1.SelectCommand = cmd;
        sqlDataAdapter1.Fill(dataSet41);
        sqlConnection1.Close();
    }
