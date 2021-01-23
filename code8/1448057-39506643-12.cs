    void Main()
    {
    	using (var ctx = new TestContext())
    	{
    		var hash = new Hashtable();
    		hash.Add("A", "A");
    		ctx.Settings.Add(new Settings { Hash = hash });
    		ctx.SaveChanges();
            // load them up...
            ctx.Settings.ToArray().Select(_ => _.Hash).Dump();
    	}
    }
