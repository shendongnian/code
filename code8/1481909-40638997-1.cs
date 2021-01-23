	List<OracleParameter> prms = new List<OracleParameter>();
	prms.Add(new OracleParameter("ROOM", OracleDbType.Varchar2, ROOM, ParameterDirection.Input));
	prms.Add(new OracleParameter("SUBMITDATE", OracleDbType.Date, SUBMITDATE ?? System.DBNull.Value, ParameterDirection.Input));
	// note that because you are using a nullable type as input you should pass in DBNull.Value as the value if the value is null in your c# code.
    var strQuery = "SELECT * from LIMS_SAMPLE_RESULTS_VW where ROOM = :ROOM and SUBMIT_DATE = :SUBMITDATE";
