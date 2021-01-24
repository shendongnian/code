    string[] ids = { "Item1", "Item2", "Item3", "Item4" };
    OracleParameter parameter = new OracleParameter();
    parameter.ParameterName = "inIDs";
    parameter.OracleDbType = OracleDbType.Array;
    parameter.Direction = ParameterDirection.Input;
    parameter.UdtTypeName = "TEST.TBL_IDS";
    parameter.Value = ids ;
