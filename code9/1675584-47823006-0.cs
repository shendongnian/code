	var records = new []
	{
		new { H1 = "Foo", H2 = "Bar" },
		new { H1 = "Qaz", H2 = "Waz" }
	};
	
	using (var tw = new System.IO.StringWriter())
	{
		using (var cw = new CsvHelper.CsvWriter(tw))
		{
			cw.WriteRecords(records);
			var output = tw.ToString();
			Console.WriteLine(output);
		}
	}
