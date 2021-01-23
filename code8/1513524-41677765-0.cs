        [Test]
        public void FakeSite()
        {
            using (Db db = new Db("web")
            {
                new DbItem("NL") { { "Title", "NL Site" } }
            })
            {
                Item siteItem = db.GetItem("/sitecore/content/NL");
                // create a fake site context
                var fakeSite = new Sitecore.FakeDb.Sites.FakeSiteContext(
                    new Sitecore.Collections.StringDictionary
                    {
                        { "name", "website" }, { "database", "web" }, { "rootPath", "/sitecore/content/NL" }
                    });
                // switch the context site
                using (new Sitecore.Sites.SiteContextSwitcher(fakeSite))
                {
                    Assert.AreEqual("website", Sitecore.Context.Site.Name);
                    Assert.AreEqual("web", Sitecore.Context.Site.Database.Name);
                    var rootItem = Context.Site.Database.GetItem(Context.Site.RootPath);
                    Assert.IsNotNull(rootItem);
                }
            }
        }
