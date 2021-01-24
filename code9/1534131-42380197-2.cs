	SqlParameter sqlParam = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
	sqlParam.Direction = ParameterDirection.Output;
	param[6] = sqlParam;
	r = _obj.ExecuteNonquery("SampleAddUser1", CommandType.StoredProcedure, param.ToArray());
	// get the returned parameter
	Guid? userId = sqlParam.Value as Guid?;
