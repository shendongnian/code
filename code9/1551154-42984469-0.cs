	using(TestEntities DB = new TestEntities())
	{
		BD.Articles.Add(new Article() { Id = 0, Category = "Category1",  Title = "Title1"});
		BD.Articles.Add(new Article() { Id = 0, Category = "Category2", Title = "Title2" });
		DB.SaveChanges();
	}
	
