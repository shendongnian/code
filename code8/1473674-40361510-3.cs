    using (var conn = new SqlConnection( @"datasource=localhost;port=3306;username=root;password=xdmemes123"))
    {
        conn.Open();
        var command = new SqlCommand("", conn);
        command.CommandText = "select * from life.players where DBname='@sqlName' and DBpass='@sqlPass";
        command.Parameters.Add("@sqlName", SqlDbType.VarChar ).Value = this.username.Text;         
        command.Parameters.Add("@sqlPass", SqlDbType.VarChar ).Value = this.password.Text;
        using (SqlDataReader myReader = command.ExecuteReader())
        {
           while (myReader.Read())
           {
               string value = myReader["COLUMN NAME"].ToString();
           }
        }    
    }
