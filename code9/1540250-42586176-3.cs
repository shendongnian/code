    using (var cmd = new OdbcCommand())
    {
        cmd.Connection = connAccess;
        cmd.CommandText = "SELECT ID, TextField AS txtcol FROM Table1 WHERE ID<=1000";
        using (OdbcDataReader rdr = cmd.ExecuteReader())
        {
            using (var sbc = new SqlBulkCopy(connStrSqlClient))
            {
                sbc.DestinationTableName = "BulkTable";
                sbc.WriteToServer(rdr);
            }
        }
    }
