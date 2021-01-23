    Int32 columnSize = 0;
    string sql = "SELECT CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'user_info' AND COLUMN_NAME = 'searches'";
    string connString = "Your Sql Server Connection String";
    using (SqlConnection conn = new SqlConnection(connString))
    {
       SqlCommand cmd = new SqlCommand(sql, conn);
       try
       {
          conn.Open();
          columnSize = (Int32)cmd.ExecuteScalar();
       }
       catch (Exception ex)
       {
          Console.WriteLine(ex.Message);
       }
    }
