    private Thing FindThing(Thing thing, string name)
    {
    	if (thing.name == name)
    		return thing;
    	foreach (var subThing in thing.childFolders.Concat(thing.childComponents))
    	{
    		var foundSub = FindThing(subThing, name);
    		if (foundSub != null)
    			return foundSub;
    	}
    	return null;
    }
    
    class RootObject
    {
    	public Thing data { get; set; }
    }
    
    class Thing
    {
    	public int id { get; set; }
    	public string name { get; set; }
    	public List<Thing> childFolders { get; set; } = new List<Thing>();
    	public List<Thing> childComponents { get; set; } = new List<Thing>();
    }
