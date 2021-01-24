	var Doe = new List<string>() { "John Doe", "21", "USA" };
	List<List<string>> list1 = new List<List<string>>();
	List<List<string>> list2 = new List<List<string>>();
    list1 = new List<List<string>>{
		Doe,
		new List<string>(){ "John Brown", "20", "Canada" },
	};
	list2 = new List<List<string>>{
	   Doe,
	   new List<string>(){ "John Mark", "22", "Brazil" },
    };
	var intersect = list1.Where(a => list2.Contains(a)).ToList();
	list1.RemoveAll(i => intersect.Contains(i));
	list2.RemoveAll(i => intersect.Contains(i));
