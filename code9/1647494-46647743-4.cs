	IList<MyAbstractClass> list = new List<MyAbstractClass>();
	list.Add(new MyAbstractClass());
	list.Add(new MyImpClass());
	foreach (var item in list)
	{
		item.GetValue("Testing...");
	}
