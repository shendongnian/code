    string query = "INSERT INTO tbl_score (personality, style, poise, audience, total) " +
                   "VALUES (@personality, @style, @poise, @audience, @total);";
    
    
    using (MySqlCommand cmd = new MySqlCommand(query, con))
    {
        // set the parameter values	
        cmd.Parameters.Add("@personality", MySqlDbType.VarChar, 100).Value = textBox1.Text;
    	cmd.Parameters.Add("@style", MySqlDbType.VarChar, 100).Value = textBox2.Text;
    	cmd.Parameters.Add("@poise", MySqlDbType.VarChar, 100).Value = textBox3.Text;
    	cmd.Parameters.Add("@audience", MySqlDbType.VarChar, 100).Value = textBox4.Text;
    	cmd.Parameters.Add("@total", MySqlDbType.VarChar, 100).Value = textBox5.Text;
    
        // open connection, execute INSERT query, close connection
        con.Open();
    	int rowsInserted = cmd.ExecuteNonQuery();
    	con.Close();
    }
    
    MessageBox.Show("Succesfully Voted");
