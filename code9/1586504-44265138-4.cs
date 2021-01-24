    void DoSomething(IEnumerable<MyRecord> records)
    {
        ...
        //Set the TVP value
        var tvpParam=sqlCommand.Parameters.Add("@SomeUDTArg",SqlDbType.Structured);  
        tvpParam.Value=(records==null)?DefaultValues:records.ToDataTable();
        //Run it
        sqlCommand.ExecuteNonQuery();
        ...
    }
