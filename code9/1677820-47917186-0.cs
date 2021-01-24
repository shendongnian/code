    using (var command2 = new SqlCommand(sql2, connection)) 
    {
    	command2.Parameters.AddWithValue("@Value1", TextBox1.Text);
    	command2.Parameters.AddWithValue("@Value2", DateTime.Now);
    	command2.ExecuteNonQuery();
    }
