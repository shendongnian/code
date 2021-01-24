    using (SqlConnection conn = new SqlConnection("yourConnectionString"))
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection = conn;
        cmd.Parameters.AddWithValue("@word", word);                
        cmd.CommandText = @"INSERT INTO tablenew(wordlist) VALUE(@word)";
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
