    using (var Conn = new MySqlConnection("Server=spet-il-cent-02;Port=3306;Database=test;Uid=test;Pwd=test123;CharSet=utf8;"))
    {
        Conn.Open();
        MySqlTransaction Tran = Conn.BeginTransaction();
        using (var Cmd = new MySqlCommand("UPDATE testing SET testBalance = testBalance + 10 WHERE testID = 1", Conn))
        {
            Cmd.Transaction = Tran;
            Cmd.ExecuteNonQuery();
        }
        using (var Cmd = new MySqlCommand("UPDATE testing SET testBalance = testBalance + 10 WHERE testID = 2", Conn))
        {
            Cmd.Transaction = Tran;
            Cmd.ExecuteNonQuery();
        }
        Tran.Rollback();
    }
