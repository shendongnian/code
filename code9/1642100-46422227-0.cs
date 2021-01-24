    using (Connection = new SqlConnection(connectionString))
    {
        connection.Open();
        
        using (SqlDataAdapter adapter = new SqlDataAdapter("INPUT INTO Person", Connection))//, Connection
            {
                DataTable RegisterTable = new DataTable();
                adapter.Fill(RegisterTable); //System.InvalidOperationException: 'The ConnectionString property has not been initialized.' TO FIX
    
                string name = textBox1.Text;
                string organisation = textBox3.Text;
                DateTime Time = DateTime.Parse(textBox2.Text);
                string strDateTimeIn = Time.ToString("yyyy-MM-dd HH:mm:ss.ffff");
                string query = "INSERT INTO Person (Name,Organisation,TimeIn) VALUES('" + name + "','" + organisation + "','" +strDateTimeIn+ "')";
                SqlCommand SignIn = new SqlCommand(query,Connection);
                SignIn.ExecuteNonQuery();
            }
    }
