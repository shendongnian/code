    string sql = "SELECT name from student where id = @id";
    using (SqlConnection connection = new SqlConnection(someConnectionString))
    using (SqlCommand command = new SqlCommand(sql, connection))
    {
        command.Parameters.Add(new SqlParameter("id", someIdVariable));
        var results = command.ExecuteReader();
    }
