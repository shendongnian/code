	public int Compare(object a, object b)
	{
	    var gA = a as MyObj;
	    var gB = b as MyObj;
	    //Handle null values, same references...
	    if(gA.Favorite != gB.Favorite) return gA.Favorite.CompareTo(gB.Favorite);
	    if(gA.Count != gB.Count) return gA.Count.CompareTo(gB.Count);
	    return gA.Name.CompareTo(gB.Name);
	}
