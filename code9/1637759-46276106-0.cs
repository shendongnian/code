    [TestCase]
    public void FooActionResultTest()
    {
        // arrange
        var itemId = ID.NewID;
        using (var db = new Db
        {
            new DbItem("Some Item", itemId)
            {
                new DbField(SitecoreFieldIds.WTW_REDIRECT_TO) { Value = "{some-raw-value}" }
            }
        })
        {   
    		// act	
    		Sitecore.Context.Item = db.GetItem(itemId);
            
            // assert
            Sitecore.Context.Item[SitecoreFieldIds.WTW_REDIRECT_TO].Should().Be("{some-raw-value}");
        }
    }
