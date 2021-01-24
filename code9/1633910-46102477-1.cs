	DataTable dt = new DataTable();
	DataTable d1 = new DataTable();
	//Set the IDs you wish to pass
	DataTable dtParam = new DataTable();
	dtParam.Columns.Add("Value", typeof(int));
	dtParam.Rows.Add(1);
	dtParam.Rows.Add(2);
	using (SqlConnection cn = new SqlConnection("cnxstring"))
	using (SqlCommand cmd1 = new SqlCommand("proc_getproductslist", cn, sqlTran))
	{
		cn.Open();
		cmd1.CommandType = CommandType.StoredProcedure;
		//Create and add the parameter
		var tableParam = new SqlParameter("@numguia", SqlDbType.Structured);
		tableParam.Value = dtParam;
		tableParam.TypeName = "dbo.ListOfInt";
		cmd1.Parameters.Add(tableParam);
		SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
		da1.Fill(d1);
	}
