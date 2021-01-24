	var table = new DataTable();
	// TODO: Add the correct column names for your TVP here
	table.Columns.Add("Column1", typeof(int));
	table.Columns.Add("Column2", typeof(DateTime));
	table.Columns.Add("Column3", typeof(decimal));
	table.Rows.Add(1, new DateTime(2017, 6, 15), 64.73);
	table.Rows.Add(1, new DateTime(2017, 6, 15), 1.3);
	sqlCommand.CommandText = "some_sproc";
	sqlCommand.CommandType = CommandType.StoredProcedure;
	sqlCommand.Parameters.Add("@SomeArg", SqlDbType.Int).Direction = ParameterDirection.Output;
	var tvp = sqlCommand.Parameters.Add("@SomeUDTArg", SqlDbType.Structured);
	tvp.TypeName = "acco.SomeUDT";
	tvp.Value = table;
	sqlCommand.ExecuteNonQuery();
	Console.WriteLine(sqlCommand.Parameters["@SomeArg"].Value);
