    ....
    using System.Data.OleDbClient;
    private void search_db(object sender, EventArgs e)
    {
        using (OleDbConnection conn = new OleDbConnection())
        {
            conn.ConnectionString = ......
            conn.Open();
            string cmdText = @"SELECT * 
                               FROM Customers 
                               WHERE (name LIKE @q1) OR (EGN LIKE @q2)";
            using(OleDbCommand command = new OleDbCommand(cmdText, conn))
            {
                command.Parameters.Add("@q1", search_query));
                command.Parameters.Add("@q2", search_query));
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                   ....
                }
            }
        }
    }
