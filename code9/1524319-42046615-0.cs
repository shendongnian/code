    var htRowValues = new Dictionary<string,string>();
    using (var mysqlConnection = Sirius.GetServer().GetDatabaseManager().GetConnection())
    {
        mysqlConnection.SetQuery("SELECT * FROM `users` WHERE `auth_ticket` = @authTicket LIMIT 1");
        mysqlConnection.AddParameter("authTicket", authTicket);
    
        var playerDataTable = mysqlConnection.GetTable();
    
        foreach (DataRow playerDataRow in playerDataTable.Rows)
        {
            foreach (DataColumn column in playerDataTable.Columns)
            {
                var columnValue = playerDataRow[column];
                htRowValues[column.ColumnName]=System.Convert.ToString(columnValue);
            }
        }
    }
