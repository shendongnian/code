            try
        {
            conn.Open();
            string sql1 = "UPDATE courseandorg SET status = @status WHERE connID = @connID";
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
            cmd1.Parameters.AddWithValue("@connID", textBox1.Text);   
            cmd1.Parameters.AddWithValue("@status", comboBox1.Text);
            cmd1.ExecuteNonQuery();
            Showlist();  //This is my funtion in  my datagridview
            your_func(); //This is new change
            conn.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        
