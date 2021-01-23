    foreach(var record in records)
    {
        OracleParameter p_ID = new OracleParameter("p_ID", OracleDbType.Decimal, record.Id, ParameterDirection.Input);
        OracleParameter p_FIELD1 = new OracleParameter("p_FIELD1", OracleDbType.Varchar2, record.FIELD1, ParameterDirection.Input);
        OracleParameter p_FIELD2 = new OracleParameter("p_FIELD2", OracleDbType.Varchar2, records.FIELD2, ParameterDirection.Input);
        OracleParameter p_FIELD3 = new OracleParameter("p_FIELD3", OracleDbType.Date, records.FIELD3, ParameterDirection.Input);
        var result = context.Database.ExecuteSqlCommand("BEGIN MY_PACKAGE.MY_PROC(:p_ID, :p_FIELD1, :p_FIELD2, :p_FIELD3); END;", p_ID, p_FIELD1, p_FIELD2, p_FIELD3);
    }
