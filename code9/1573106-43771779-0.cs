    using (var connection = new OracleConnection(connectionString))
    {
    connection.Open();
    OracleCommand command = new OracleCommand
    {
        Connection = connection,
        CommandType = CommandType.StoredProcedure,
        CommandText = "appowner.MEMBER_DATA_PACKAGE.UPDATE_NOTES_V001",
        BindByName = true
    };
    command.Parameters.Add(new OracleParameter("TAU_UID_IN", OracleDbType.Varchar2, ParameterDirection.Input)).Value = "7400";
    command.Parameters.Add(new OracleParameter("INCOMING_FUNC_IN", OracleDbType.Varchar2, ParameterDirection.Input)).Value = "PROVCOUNT";
    command.Parameters.Add(new OracleParameter("INCOMING_TEXT_IN", OracleDbType.Varchar2, ParameterDirection.Input)).Value = "Pypestream testing.";
    command.Parameters.Add(new OracleParameter("SYS_SOURCE_IN", OracleDbType.Varchar2, ParameterDirection.Input)).Value = "CRM";
    command.Parameters.Add(new OracleParameter("USER_ID_IN", OracleDbType.Varchar2, ParameterDirection.Input)).Value = "jac";
    command.Parameters.Add(new OracleParameter("O_STATUS", OracleDbType.Varchar2, ParameterDirection.OutPut));
    command.ExecuteNonQuery();
    Console.WriteLine($"Insert output value is '{command.Parameters["O_STATUS"].Value.ToString()}'");
    }
