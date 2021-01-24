    DataTable words = new DataTable();
    string word = string.Empty;
            
    using (SqlConnection conn = new SqlConnection("yourConnectionString"))
    {
         SqlCommand cmd = new SqlCommand();
         cmd.CommandType = System.Data.CommandType.Text;
         cmd.Connection = conn;
         cmd.CommandText = @"SELECT wordlist FROM tableold WHERE username IN(SELECT username FROM tablenew)";
         SqlDataAdapter adap = new SqlDataAdapter();
         adap.SelectCommand = cmd;
         adap.Fill(words);
    }
    if (words != null && words.Rows.Count > 0)
    {
         word = words.Rows[0].Field<string>("wordlist"); // for example
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
    }
