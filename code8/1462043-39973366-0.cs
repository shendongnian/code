    var connectionString = "server=(local);integrated security=true;"
    string sql = "SELECT name FROM master.dbo.sysdatabases";
    SqlConnection conn= new SqlConnection(connectionString);
    conn.Open();
    SqlCommand cmd = new SqlCommand(sql, conn);
    SqlDataReader reader = cmd.ExecuteReader();
    
            while (reader.Read())
            {
                combobox1.Items.Add(reader["name"]);
    
            }
