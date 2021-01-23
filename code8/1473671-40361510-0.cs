    using (var conn = new SqlConnection( @"Connection string"))
    {
        conn.Open();
        var command = new SqlCommand("", conn);
        command.CommandText = "select * from life.players where DBname='@sqlName' and DBpass='@sqlPass";
        command.Parameters.AddWithValue("@sqlName", this.username.Text );          
        command.Parameters.AddWithValue("@sqlPass", this.password.Text );
        using (SqlDataReader myReader = command.ExecuteReader())
        {
           while (myReader.Read())
           {
               string value = myReader["COLUMN NAME"].ToString();
           }
        }    
    }
