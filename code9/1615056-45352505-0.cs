        // this is just a sample. You need to adjust it to your needs
        string connectionStr = "Data Source=ServerName;Initial Catalog=DataBaseName;Integrated Security=SSPI;";
        SqlConnection sqlConnection1 = new SqlConnection(connectionStr);
        SqlCommand cmd = new SqlCommand(sqlConnection1 );
        SqlDataReader reader;
        cmd.CommandText = "SELECT TOP (1) IDENT_CURRENT('dbo.license_info') FROM dbo.license_info";
        cmd.CommandType = CommandType.Text;
        sqlConnection1.Open();
        reader = cmd.ExecuteReader();
        List<string> results = new List<string>();
        
        if(reader.HasRows)
        {
            while(reader.Read())
            {
                results.Add(reader[0].ToString());
            }
        }
        sqlConnection1.Close();
