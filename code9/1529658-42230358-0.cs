    string sqlInsertStmt = "INSERT INTO PRODUCT (id,name,price) VALUES (@id, @name, @price)";
    string connectionString = "sqlserver connection string";
    //sample connection string can be like
    //connectionString="Data Source=ServerName;Initial Catalog=DatabaseName;Integrated Security=False;User Id=userid;Password=password;MultipleActiveResultSets=True";
    using (SqlConnection conn = new SqlConnection(connString))
    {
      conn.Open();
      foreach(var product in CSVProducts)
      {
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = conn;
            cmd.CommandString = sqlInsertStmt;
            cmd.Parameters.AddWithValue("@id", product.Id);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@val", product.Price);
            try
            {
                cmd.ExecuteNonQuery();
            }
            Catch(SqlException e)
            {
                //log exception and handle error
            }
        }
      }
    }
