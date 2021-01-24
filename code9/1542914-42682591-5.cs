    using StringOrdinalIgnoreCase = JDanielSmith.System.String<JDanielSmith.System.OrdinalIgnoreCase>;
    [TestMethod]
    public void StringOrdinalIgnoreCaseDictionary()
    {
	    var d = new Dictionary<StringOrdinalIgnoreCase, int>() { { "abc", 1 }, { "def", 2 } };
	    Assert.IsTrue(d.ContainsKey("ABC"));
	    try
	    {
		    d.Add("DEF", 2);
		    Assert.Fail();
	    }
	    catch (ArgumentException) { }
    }
