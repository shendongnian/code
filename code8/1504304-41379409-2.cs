    void GetUsername(string Username)
    {
        var sql = @"
            SELECT UserName
            FROM tblLogin
            WHERE UserId = @Username
        ";
        var connectionString = @"
            Data Source=METHOUN-PC;
            Initial Catalog=ITReportDb;
            Integrated Security=True
        ";
        using (var con = new SqlConnection(connectionString)) {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Username", Username);
            TextBox1.Text = cmd.ExecuteScalar()?.ToString();
            con.Close();
        }
    }
