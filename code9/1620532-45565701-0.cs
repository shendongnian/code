    	using (SqlCommand commandInsert = new SqlCommand(YourQuery, YourConnectionString))
			{
				commandInsert.Parameters.Add(parameterAccount);
				commandInsert.Parameters.Add(parameterPassword);
				commandInsert.Parameters.Add(parameterBalance);
				commandInsert.Parameters.Add(parameterAccountStatus);
				commandInsert.Parameters.Add(parameterDateOfCreation);
				commandInsert.ExecuteNonQuery();
				connection.Close();
			};
