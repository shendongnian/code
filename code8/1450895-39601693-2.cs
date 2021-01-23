	// DO NOT reuse connections, create a new one when needed!
	using(var conn = new SqlConnection(/*use a connection from the web/app .config*/))
	{
		const string sql = "SELECT studnum,course,f_name,l_name,color_image FROM table3 WHERE f_name = @name";
		command = new SqlCommand(sql, conn);
		command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar) { Value = textBoxfname.Text});
		conn.Open();
		/* rest of code unchanged but do not call conn.Close(), the using block will do this for you
		
	}
