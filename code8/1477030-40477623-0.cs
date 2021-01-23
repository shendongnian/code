    using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
    {
        conn.Open();
        using(SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = "INSERT INTO testing (name) VALUES (@name)";
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtBox;
            cmd.Connection = conn;        
            cmd.ExecuteNonQuery();
        }
    }
