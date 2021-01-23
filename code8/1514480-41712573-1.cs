	List<TestClass> list1 = new List<TestClass>();
	list1.Add(new TestClass() { TestInteger = 1, TestString = "t1" });
	list1.Add(new TestClass() { TestInteger = 2, TestString = "t2" });
	
	List<TestClass> list2 = new List<TestClass>();
	list2.Add(new TestClass() { TestInteger = 1, TestString = "t1" });
	list2.Add(new TestClass() { TestInteger = 3, TestString = "t3" });
	
	IEnumerable<TestClass> list3 = list1.Union(list2);
