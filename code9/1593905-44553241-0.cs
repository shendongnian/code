    string sql = 
      "BEGIN;" + 
      "UPDATE testing SET testBalance = testBalance + 10 WHERE testID = 1;" +
      "UPDATE testing SET testBalance = testBalance - 10 WHERE testID = 2;" +
      "COMMIT;";
    using (var Conn = new MySqlConnection("Server=spet-il-cent-02;Port=3306;Database=test;Uid=test;Pwd=test123;CharSet=utf8;"))
    using (var Cmd = new MySqlCommand(sql, Conn))
    {
        Conn.Open();
        Cmd.ExecuteNonQuery();
    }
