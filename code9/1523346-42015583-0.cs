    using (var conn = new OdbcConnection(sConn))
    {
        const string cmdIns = "{ call spSound_Insert(?,?,?,?) }";
        using (var sqlCmdIns = new OdbcCommand(cmdIns, conn))
        {
            sqlCmdIns.CommandType = CommandType.StoredProcedure;
            sqlCmdIns.Parameters.Add("", OdbcType.NVarChar, 40).Value = "123";
            sqlCmdIns.Parameters.Add("", OdbcType.VarBinary, -1).Value = new Byte[128];
            sqlCmdIns.Parameters.Add("", OdbcType.Bit).Value = true;
            sqlCmdIns.Parameters.Add("", OdbcType.NVarChar, 128).Value = "test note";
               
            conn.Open();
        }
    }
