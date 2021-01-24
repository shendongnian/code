    public List<SomeObject> GetMeSomethingFromDB(string myParam, int anotherParam)
    {
        using (OracleConnection conn = new OracleConnection(Settings.ConnectionString))
        using (OracleCommand cmd = new OracleCommand("STORED_PROC_NAME", conn))
        {   
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("IN_MY_PARAM", OracleDbType.Varchar2)).Value = myParam;
            cmd.Parameters.Add(new OracleParameter("IN_ANOTHER_PARAM", OracleDbType.Int32)).Value = anotherParam;
            cmd.Parameters.Add(new OracleParameter("OUT_REF_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
            using (OracleDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                     SomeObject someObject = new SomeObject
                     {
                         SomeId = (int)dataReader["SOME_ID"],
                         SomeStringValue = dataReader["SOME_STRING_VALUE"].ToString()
                     };
                     result.Add(someObject);
                }
            }
        }
    	return result;
    }
