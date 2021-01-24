    using(var cmd1 = new SqlCommand("DELETE FROM User WHERE Id = @Id", conn))
    {
        cmd1.Parameters.Add("@Id", SqlDbType.Int).Value = Int.Parse(TextBox1.Text);
        conn.Open();
        cmd1.ExecuteNonQuery();
    }
