    using(SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
	{
		SqlCommand com = new SqlCommand();
		SqlDataReader sqlReader;
		com.CommandText = "Select id from @tableName";
		com.CommandType = CommandType.Text;
		com.Parameters.Add(new SqlParameter("@tableName", tableName);
		com.Connection = sqlCon;
		sqlCon.Open();
		sqlReader = com.ExecuteReader();
		var dt = new DataTable();
		dt.Load(sqlReader); //Query output is in dt now
	}
