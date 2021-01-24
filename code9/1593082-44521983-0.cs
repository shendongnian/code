    using (SQLiteCommand sqlCommand = new SQLiteCommand("select count(FileName) from downloadedfiles where fileName = @Filename", sql_con))
    {
      sql_con.Open();
      sqlCommand.Parameters.Add(new SQLiteParameter("@Filename", fileName));
      int userCount = (int)sqlCommand.ExecuteScalar();
      if (userCount > 0)
      {
         returnValue = true;
      }
    }
