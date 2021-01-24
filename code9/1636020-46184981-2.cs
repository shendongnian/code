    var parameter = new SqlParameter();
    parameter.SqlDbType = SqlDbType.Structured;
    parameter.ParameterName = "@Ids";
    parameter.Value = table;
    parameter.TypeName = "dbo.IntTTV";
    var parameters = new SqlParameter[1]
    {
      parameter
    };
