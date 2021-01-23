    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO TableName (Col1, Col2, ColN) VALUES (@Col1, @Col2, @ColN)");
        cmd.CommandType = CommandType.Text;
        cmd.Connection = connection;
        cmd.Parameters.AddWithValue("@Col1", txtName.Text);
        cmd.Parameters.AddWithValue("@Col2", txtPhone.Text);
        cmd.Parameters.AddWithValue("@ColN", txtAddress.Text);
        connection.Open();
        cmd.ExecuteNonQuery();
    }
