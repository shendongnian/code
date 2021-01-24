	List<Foo> foos = new List<Foo>()
	{
		new Foo(){ Id = 1, Name = "item-1"},
		new Foo(){ Id = 2, Name = "item-2"},
		new Foo(){ Id = 3, Name = "item-3"},
		new Foo(){ Id = 4, Name = "item-4"}
	};
	List<Bar> bars = new List<Bar>()
	{
		new Bar(){ Id = 1, Date = "01.01.2017"},
		new Bar(){ Id = 2, Date = "01.02.2017"}
	};
	
	IEnumerable<dynamic> result = foos.GroupJoin(bars,
		f => f.Id,
		b => b.Id,
		(foo, bar) => new
		{
			Id = foo.Id,
			Name = foo.Name,
			isPlanned = String.IsNullOrEmpty(bar.SingleOrDefault()?.Date),
			Date = bar.SingleOrDefault()?.Date
		});
