	protected SomeType RetrieveSearcherData(string pid)
	{
		const string Q = "SELECT price FROM tb3 WHERE pid = @pid";
		using(var cn=new SqlConnection())
		using(var cmd=new SqlCommand(Q,cn))
		{
			// I do not know what pid is but use tho correct type here as well and specify that type using SqlDbType
			cmd.Parameters.Add(new SqlParameter("@pid", SqlDbType.VarChar, 100) { Value = pid});
			cn.Open();
			using(var dr1= cmd.ExecuteReader())
			{
				if(dr1.Read())
				{
				   var result = dr1.GetDecimal(0);
				   // read something and return it either in raw format or in some object (use a custom type)
				}
				else
				  return null; // return something else that indicates nothing was found
			}
		}
	}
	
