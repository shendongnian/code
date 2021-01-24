	var scenario2 = Process(new List<Test>()
	{
		new Test { TestId = 100, Source = "Test" },
		new Test { TestId = 101, Source = "Test" }
	}, new List<Test>()
	{
		new Test { TestId = 100, Source = "DB" }
	});
	
