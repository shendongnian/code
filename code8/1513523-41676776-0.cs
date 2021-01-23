	public void HowToCreateSimpleItem()
	{
	  using (Sitecore.FakeDb.Db db = new Sitecore.FakeDb.Db
		{
		  new Sitecore.FakeDb.DbItem("Home") { { "Title", "Welcome!" } }
		})
	  {
		Sitecore.Data.Items.Item home = db.GetItem("/sitecore/content/home");
		Xunit.Assert.Equal("Welcome!", home["Title"]);
	  }
	}
	public void HowToCreateHierarchyOfItems()
	{
	  using (Sitecore.FakeDb.Db db = new Sitecore.FakeDb.Db
		{
		  new Sitecore.FakeDb.DbItem("Articles")
			{
			  new Sitecore.FakeDb.DbItem("Getting Started"),
			  new Sitecore.FakeDb.DbItem("Troubleshooting")
			}
		})
	  {
		Sitecore.Data.Items.Item articles =
		  db.GetItem("/sitecore/content/Articles");
		Xunit.Assert.NotNull(articles.Children["Getting Started"]);
		Xunit.Assert.NotNull(articles.Children["Troubleshooting"]);
	  }
	}
