	public List<Test> Process(List<Test> testList, List<Test> testListfromDb)
	{
		return 
			testListfromDb
				.Concat(testList)
				.GroupBy(x => x.TestId)
				.SelectMany(x => x.Take(1))
				.ToList();
	}
