    [TestCase]
    public void FooTest()
    {
        using (var db = new Db { })
        {
            var fakeSite = new Sitecore.FakeDb.Sites.FakeSiteContext(new Sitecore.Collections.StringDictionary
            {
                { "name", "website" }, { "database", "web" }
            });
            using (new Sitecore.Sites.SiteContextSwitcher(fakeSite))
            {
                Sitecore.Context.Site.Name.Should().Be("website");
                Sitecore.Context.Site.Database.Name.Should().Be("web");
            }
        }
    }
