    sqlCommand.CommandText = "some_sproc";
    sqlCommand.CommandType = CommandType.StoredProcedure;
    //Create the out parameter
    var outParam=sqlCommand.Parameters.Add("@SomeArg", SqlDbType.Int);
    outParam.Direction = ParameterDirection.Output;
    //Set the TVP value
    var tvpParam=sqlCommand.Parameters.Add("@SomeUDTArg",SqlDbType.Structured);
    tvpParam.Value=myTable;
    //Run it
    sqlCommand.ExecuteNonQuery();
    //And read the results
    var result=outParam.Value;
