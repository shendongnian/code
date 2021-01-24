        using(SqlConnection conn = new SqlConnection()) 
        {
            conn.ConnectionString = "Server=[server_name];Database=[database_name];Trusted_Connection=true";
    
        SqlCommand command = new SqlCommand("SELECT * FROM YourTable", conn);
        }
    using (SqlDataReader reader = command.ExecuteReader())
    {
        var list = new List<YourMappingClass>();
        while (reader.Read())
        {
            
            var obj = new YourMappingClass();
            obj.Prop1=reader[0];
            obj.Prop2=reader[1];
            list.Add(data);
        }
    }
