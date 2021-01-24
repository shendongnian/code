	var Doe = new List<string>() { "John Doe", "21", "USA" };
		
	List<List<string>> list1 = new List<List<string>>{
		Doe,
		new List<string>(){ "John Brown", "20", "Canada" },
	};
	List<List<string>> list2 = new List<List<string>>{
		Doe,
		new List<string>(){ "John Mark", "22", "Brazil" },
	};
	var intersect = list1.Intersect(list2).ToList().ToList();
	list1.RemoveAll(i => intersect.Contains(i));
	list2.RemoveAll(i => intersect.Contains(i));
