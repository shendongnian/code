    using (var bucket = Cluster.OpenBucket("TestCheck2"))
	{
		var query = bucket.CreateQuery("testcheck2", "getall");
		var data = bucket.Query<dynamic>(query);
		foreach (var item in data.Rows)
		{
			Console.WriteLine($"{item.Value.TestId}: Title: \"{item.Value.Title}\" {item.Value.Body}");
		}
	}
