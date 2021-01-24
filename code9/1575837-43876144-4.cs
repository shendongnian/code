	public static void Main()
	{
	    var x = Enumerable.Range(0, 4).Select(n => "Item " + n);
    	var current = ((System.Collections.IEnumerator)x).Current;
		//  It is an absolute certainty that this iterator will return items.
		Console.WriteLine("Current == {0}", current == null ? "(null)" : current.ToString());
	    foreach (var y in x)
    	{
			Console.WriteLine("Next Item: {0}", y);
    	}
	}
