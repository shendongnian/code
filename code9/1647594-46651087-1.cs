     public int CheckRepetitive(string connectionString,string modelName)
     {
        using(var sqlCon = new SqlConnection(connectionString))
		{
			sqlCon.Open();
        
			SqlCommand com = new SqlCommand("checkRepititiveModel", sqlCon);
			com.Parameters.Add("@modelName", SqlDbType.NVarChar).Value = modelName;
			SqlParameter retval = sqlcomm.Parameters.Add("@rc", SqlDbType.Int);
            retval.Direction = ParameterDirection.ReturnValue;
			
			com.CommandType = CommandType.StoredProcedure;
			com.ExecuteNonQuery();
			return (int)retval.Value;
		}
    }
