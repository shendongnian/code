     SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "select * from computer";
            com = new SqlCommand(str, con);
            SqlDataReader reader = com.ExecuteReader();
    
           while (reader.Read())
    {
                label1.Text = reader["ComputerName"].ToString();
    
                label2.Text = reader["ComputerIP"].ToString();
    
                label3.Text = reader["os_version"].ToString();
    
                label4.Text = reader["u_name"].ToString();
    
                label5.Text = reader["status"].ToString();
    
                label6.Text = reader["os_bits"].ToString();
    
                label7.Text = reader["nprocessor"].ToString();
    }
            reader.Close();
            con.Close();
