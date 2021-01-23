    private void button1_Click(object sender, EventArgs e)
    {       
       Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); 
       Match match = regex.Match(textBox3.Text);
       if (match.Success)
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
