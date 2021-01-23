	string userid = "User1";
	var items = new List<Item>();
	items.Add(new Book { Id = "B1", Name = "Book1", UserId = "User1", DateTime = new DateTime(2016, 11, 16, 11, 15, 00) });
	items.Add(new Book { Id = "B2", Name = "Book2", UserId = "User1", DateTime = new DateTime(2016, 11, 16, 12, 15, 00) });
	items.Add(new Book { Id = "B3", Name = "Book3", UserId = "User2", DateTime = new DateTime(2016, 11, 16, 10, 15, 00) });
	items.Add(new Comment { Id = "c1", BookId = "B3", UserId = "User1", Content = "cmt1", DateTime = new DateTime(2016, 11, 16, 11, 17, 00) });
	items.Add(new Comment { Id = "c2", BookId = "B1", UserId = "User1", Content = "cmt2", DateTime = new DateTime(2016, 11, 16, 11, 16, 00) });
	var test = (from b in items
				where b.UserId == userid
				orderby b.DateTime
				select b);
	foreach (var o in test)
	{
		Console.WriteLine(o);
	}
