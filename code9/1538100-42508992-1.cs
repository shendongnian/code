    public void InitializeCommands()
    {
        ...
        _myAccessCommand=new  new OracleCommand(query);
        _myAccessCommand.Parameters.Add("WellBore",OracleDbType.NVarchar2,20);
        ...
    }
    public void InsertData(string wellBefore,...)
    {
        using (var conn = new OracleConnection(connectionname))
        {
            conn.Open();
            _myAccessCommand.Connection=conn;
            _myAccessCommand.Parameters["WellBefore"].Value = wellBefore;
            ...            
            _myAccessCommand.ExecuteNonQuery();
        }
    }
