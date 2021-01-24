	public static Stream StoreApproved ()
	{          
		string path1 = HttpRuntime.AppDomainAppPath + "Report.csv";
		SqlConnection sqlConnection1 = new SqlConnection("CONNECTIONSTRING");
		SqlCommand cmd = new SqlCommand();
		SqlDataReader reader;
		cmd.CommandText = "ExportApproved";
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Connection = sqlConnection1;
		sqlConnection1.Open();
		reader = cmd.ExecuteReader();
		List<ModelStoreProcedureApproved> TestList = new List<ModelStoreProcedureApproved>();
		ModelStoreProcedureApproved test ;
		while (reader.Read())
		{
			test = new ModelStoreProcedureApproved();
		   // test.Id = int.Parse(reader["IdTimeTracker"].ToString());
			test.Month = reader["Month"].ToString();
			test.EmailUser = reader["Email"].ToString();
			test.Project = reader["Name"].ToString();
			test.Approved = reader["Description"].ToString();
			test.Month = reader["Month"].ToString();
			test.Year = reader["Year"].ToString();
			TestList.Add(test);
		}
		var i = TestList.FirstOrDefault();
		var mem = new MemoryStream();
		using (TextWriter fileReader = new StreamWriter(mem))
		{
			var csv = new CsvWriter(fileReader);
			csv.Configuration.Encoding = Encoding.UTF8;
			foreach (var value in TestList)
			{
				csv.WriteRecord(value);
			}
		}
		sqlConnection1.Close();
		return mem;
	}
	public ActionResult ExportToCSV()
	{
		Stream stream = Repositories.UserRepository.StoreApproved();
		return new FileStreamResult(stream, "text/csv") { FileDownloadName = "export.csv" };
	}
