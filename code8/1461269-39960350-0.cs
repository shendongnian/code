            var dbCommand = session.Connection.CreateCommand();
			dbCommand.CommandType = CommandType.StoredProcedure;
			dbCommand.CommandText = "fu_GetUserGrant";
			var returnValue = dbCommand.CreateParameter();
			{
				returnValue.ParameterName = "Return_Value";
				returnValue.DbType = DbType.Decimal;
				returnValue.Direction = ParameterDirection.ReturnValue;
			}
			var grantIdParam = dbCommand.CreateParameter();
			{
				grantIdParam.Value = grantId;
				grantIdParam.DbType = DbType.StringFixedLength;
				grantIdParam.Size = 200;
				grantIdParam.ParameterName = "m_In_GrantId";
				grantIdParam.Direction = ParameterDirection.Input;
			}
			dbCommand.Parameters.Add(returnValue);
			dbCommand.Parameters.Add(grantIdParam);
			dbCommand.ExecuteReader();
			return long.Parse(returnValue.Value.ToString());
