	Private void button1_Click(object sender, EventArgs e)
	{
		string connectionString = @"server=localhost;Initial Catalog=klantbestand;Integrated Security=SSPI;";
		string filepath = @"C:\clients TEST.csv";
		StreamReader sr = new StreamReader(filepath);
		string line = sr.ReadLine();
		string[] value = line.Split(';');
		DataTable dt = new DataTable();
		DataRow row;
		foreach (string dc in value)
		{
			dt.Columns.Add(new DataColumn(dc));
		}
		while (!sr.EndOfStream)
		{
			value = sr.ReadLine().Split(';');
			if (value.Length == dt.Columns.Count)
			{
				row = dt.NewRow();
				row.ItemArray = value;
				dt.Rows.Add(row);
			}
		}
	
		if (dt.Rows.Count>0) {
			using (SqlConnection connection = new SqlConnection(connectionString)) {
			connection.Open();
			using (SqlCommand command = connection.CreateCommand()) {
					command.CommandText = "dbo.ProcedureName";
					command.CommandType = CommandType.StoredProcedure;
					SqlParameter parameter;			   
					parameter = command.Parameters.AddWithValue("@TableTypeName", dt);				
					parameter.SqlDbType = SqlDbType.Structured;
					parameter.TypeName = "dbo.TableTypeName";
					command.ExecuteNonQuery();
				}
			}
		}        
	}
