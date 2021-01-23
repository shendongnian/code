    using (var command = oracleConnection.CreateCommand())
    {
        command.CommandText = "DBMS_STATS.GATHER_TABLE_STATS";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new OracleParameter("ownname", OracleDbType.Varchar2));
        command.Parameters.Add(new OracleParameter("tabname", OracleDbType.Varchar2));
        command.Parameters.Add(new OracleParameter("estimate_percent", OracleDbType.Decimal));
        command.Parameters[0].Value = schemaname;
        command.Parameters[1].Value = tablename;
        command.Parameters[2].Value = 10M;
        int ret = command.ExecuteNonQuery();
    }
