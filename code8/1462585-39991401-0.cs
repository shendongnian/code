    private void button1_Click(object sender, EventArgs e)
    {        
       int atpos = textBox3.Text.IndexOf("@"); 
       int dotpos = textBox3.Text.LastIndexOf(".");
        if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= textBox3.Text.Length)
        {
            MessageBox.Show("not a valid email address");
        }
        else
        {
          conn.Open(); 
          SqlCommand cmd = conn.CreateCommand(); 
          cmd.CommandType = CommandType.Text; 
          cmd.CommandText = "insert into Table1 values('" + textBox1.Text+"','" +   textBox2.Text +"','" + textBox3.Text +"')"; 
          cmd.ExecuteNonQuery();
          conn.Close();
          textBox1.Text = "";
          textBox2.Text = "";
          textBox3.Text = "";
          displayData();
          MessageBox.Show("data inserted successfully");
        }      
    }
