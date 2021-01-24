    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
    {
        using (var command = new SqlCommand("insert into sms (col1) values(@col1"))
        {
            command.Parameters.AddWithValue("@col1", DateTime.Now);
            con.Open();
            command.ExecuteNonQuery();
        }
    }
