	var intermediate = JsonConvert.DeserializeObject<IntermediateTestData>(json);
	var testData = new TestData
	{
		Name = intermediate.Name,
		Data = intermediate.Data.Select(d => new TestDataItem
		{
			Date = DateTime.Parse(d[0]),
			Value = double.Parse(d[1])
		})
		
	};
