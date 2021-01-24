	DataTable parent = new DataTable();
	parent.Columns.Add("Id1", typeof(string));
	parent.Columns.Add("Id2", typeof(string));
	DataRow r1 = parent.NewRow();
	r1["Id1"] = "1";
	r1["Id2"] = DBNull.Value;
	parent.Rows.Add(r1);
	DataRow r3 = parent.NewRow();
	r3["Id1"] = "1";
	r3["Id2"] = "2";
	parent.Rows.Add(r3);
	DataTable child1 = new DataTable();
	child1.Columns.Add("Id1", typeof(string));
	child1.Columns.Add("Id2", typeof(string));
	child1.Columns.Add("BeginDate", typeof(DateTime));
	child1.Columns.Add("SomeData", typeof(float));
	DataRow r2 = child1.NewRow();
	r2["Id1"] = "1";
	r2["Id2"] = DBNull.Value;
	child1.Rows.Add(r2);
	DataRow r4 = child1.NewRow();
	r4["Id1"] = "1";
	r4["Id2"] = "2";
	child1.Rows.Add(r4);
	var dataToReturn =
		from
		p in parent.AsEnumerable()
		join c1 in child1.AsEnumerable()
		on new { Id1 = p["Id1"], Id2 = p["Id2"] }
		equals new { Id1 = c1["Id1"], Id2 = c1["Id2"] }
		select new
		{
			Id1 = p["Id1"],
			Id2 = p["Id2"]
		};
	
	foreach(var l in dataToReturn)
	{
		Console.WriteLine(l.Id1 + "|" + l.Id2);
	}
	Console.ReadKey();
