        using(var sqlCon = new SqlConnection(connectionString))
		{
			sqlCon.Open();
        
			SqlCommand com = new SqlCommand("checkRepititiveModel", sqlCon);
			com.Parameters.AddWithValue("@modelName", modelName);
			
			var result = new SqlParameter();
			result.DbType = DbType.Int32;
			result.Direction = ParameterDirection.ReturnValue;
			com.Parameters.Add(result);
			
			com.CommandType = CommandType.StoredProcedure;
			com.ExecuteNonQuery();
			return (int)result.Value;
		}
    }
