    using (var con = new SqlConnection("connectionString here"))
    {
	   con.Open();
	   var sql = "INSERT INTO  my_table (a, b, c) VALUES (@a,@b,@c);"
	
	   using (var comm = new SqlCommand(sql, con))
	   {
		   comm.Parameters.Add("@a", SqlDbType.Int);
		   comm.Parameters.Add("@b", SqlDbType.NVarChar);
		   comm.Parameters.Add("@c", SqlDbType.Int);
		   foreach (var item in collection) {
		   {
			   comm.Parameters["@a"].Value = aVal;
			   comm.Parameters["@b"].Value = bVal;
			   comm.Parameters["@b"].Size = bVal.Length;
			   comm.Parameters["@c"].Value = cVal;
			
			   comm.ExecuteNonQuery();
		   }
	   }
    }
