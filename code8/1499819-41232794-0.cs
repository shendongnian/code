    var list = new List<Homework>();
	
	var one = new Homework()
	{
		Title = "Title 1",
		Description = "Description",
		Subject = "Subject",
		DueDate = new DateTime(2016,1,1),
		ImportanceLevel = 1,
		IsComplete = false
	};
	
	var two = new Homework()
	{
		Title = "Title 2",
		Description = "Description",
		Subject = "Subject",
		DueDate = new DateTime(2016,1,1),
		ImportanceLevel = 1,
		IsComplete = false
	};
	
	var three = new Homework()
	{
		Title = "Title 3",
		Description = "Description",
		Subject = "Subject",
		DueDate = new DateTime(2016,1,1),
		ImportanceLevel = 1,
		IsComplete = false
	};
	
	list.Add(one);
	list.Add(two);
	list.Add(three);
	
	SaveHomeworks(list);
