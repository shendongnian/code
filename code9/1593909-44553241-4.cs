    using (var Conn = new MySqlConnection("Server=spet-il-cent-02;Port=3306;Database=test;Uid=test;Pwd=test123;CharSet=utf8;"))
    using (var Cmd = new MySqlCommand("UPDATE testing SET testBalance = testBalance + 10 WHERE testID = @testID", Conn))
    {
        Conn.Open();
        Cmd.Transaction = Conn.BeginTransaction();
        Cmd.Parameteres.Add("@testID", MySqlDbType.Int32).Value = 1;
        Cmd.ExecuteNonQuery();
        Cmd.Parameters["testID"].Value = 2; //I can't remember at the moment if you need the "@" here or not
        Cmd.ExecuteNonQuery();
        Tran.Rollback();
    }
