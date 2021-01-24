     private void button1_Click(object sender, EventArgs e)
     {
         string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
         using (SqlConnection conn = new SqlConnection(connString))
         {
             SqlCommand cmd = new SqlCommand("ups_StudentInsertDetails", conn);
             cmd.Parameters.AddWithValue("Name", textBox1.Text);
             cmd.Parameters.AddWithValue("Email", textBox2.Text);
                
       	     //then open connection
             cmd.Connection.Open();
        
             cmd.ExecuteNonQuery();
             MessageBox.Show("Data saved successfully!");
        } 
     }
