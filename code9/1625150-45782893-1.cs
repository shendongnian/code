    using RefactorThis.GraphDiff;
    
    IEnumerable<Foo> foos = ...;
    using (var db = new YourDbContext())
    {
    	foreach (var foo in foos)
    	{
    		db.UpdateGraph(foo, fooMap =>
    			fooMap.OwnedCollection(f => f.Bars, barMap =>
    				barMap.OwnedCollection(b => b.Bazs)));
    	}
    	db.SaveChanges();
    }
