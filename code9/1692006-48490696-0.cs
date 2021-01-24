    DynamicParameters parameters = new DynamicParameters();
    parameters.Add("Param2", "TheCode");
    parameters.Add("Param3", "TheTitle");
    parameters.Add("Param4", 4);
    parameters.Add("Param5", "2018-01-28");
    parameters.Add("Param6", true);
    parameters.Add("Param7", false);
    parameters.Add("Param8", 300);
    parameters.Add("Param9", 30);
    parameters.Add("Param10", 3);
    parameters.Add("Param11", "2018-01-28");
    parameters.Add("Param12", true);
    parameters.Add("Param13", true);
    
    var insertedId = await connection.ExecuteAsync(query, parameters, transaction);
