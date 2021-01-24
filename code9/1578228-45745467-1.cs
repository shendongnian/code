    using (var bucket = Cluster.OpenBucket("TestCheck2"))
	{
		var query = bucket.CreateQuery("dev_testcheck2", "getall");
		var data = bucket.Query<dynamic>(query);
		foreach (var item in data.Rows)
		{
			Console.WriteLine($"{item.Value[0]}: Title: \"{item.Value[1]}\" Body: {item.Value[2]}");
		}
	}
