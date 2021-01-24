    db.Configuration.AutoDetectChangesEnabled = false;
    var fooIds = foos.Where(f => f.Id != 0).Select(f => f.Id).ToList();
    var oldFoos = db.Foos
    	.Where(f => fooIds.Contains(f.Id))
    	.Include(f => f.Bars.Select(b => b.Bazs))
    	.ToDictionary(f => f.Id);
    foreach (var foo in foos)
    {
    	Foo dbFoo;
    	if (!oldFoos.TryGetValue(foo.Id, out dbFoo))
    	{
    		dbFoo = db.Foos.Create();
    		dbFoo.Bars = new List<Bar>();
    		db.Foos.Add(dbFoo);
    	}
    	db.Entry(dbFoo).CurrentValues.SetValues(foo);
    	var oldBars = dbFoo.Bars.ToDictionary(b => b.Id);
    	foreach (var bar in foo.Bars)
    	{
    		Bar dbBar;
    		if (!oldBars.TryGetValue(bar.Id, out dbBar))
    		{
    			dbBar = db.Bars.Create();
    			dbBar.Bazs = new List<Baz>();
    			db.Bars.Add(dbBar);
    			dbFoo.Bars.Add(dbBar);
    		}
    		else
    		{
    			oldBars.Remove(bar.Id);
    		}
    		db.Entry(dbBar).CurrentValues.SetValues(bar);
    		var oldBazs = dbBar.Bazs.ToDictionary(b => b.Id);
    		foreach (var baz in bar.Bazs)
    		{
    			Baz dbBaz;
    			if (!oldBazs.TryGetValue(baz.Id, out dbBaz))
    			{
    				dbBaz = db.Bazs.Create();
    				db.Bazs.Add(dbBaz);
    				dbBar.Bazs.Add(dbBaz);
    			}
    			else
    			{
    				oldBazs.Remove(baz.Id);
    			}
    			db.Entry(dbBaz).CurrentValues.SetValues(baz);
    		}
    		db.Bazs.RemoveRange(oldBazs.Values);
    	}
    	db.Bars.RemoveRange(oldBars.Values);
    }
    db.Configuration.AutoDetectChangesEnabled = true;
