    using ( OracleCommand command = new OracleCommand () ) {
        command.Connection = connection;
        command.BindByName = true;
        command.CommandText = "INSERT INTO objects(name)VALUES(:objectName)RETURNING id INTO :objectId";
        command.Parameters.Add ( "objectName", OracleDbType.Varchar2, ParameterDirection.Input );
        command.Parameters.Add ( "objectId", OracleDbType.Int64, ParameterDirection.ReturnValue);
        command.ExecuteNonQuery ();
    }
