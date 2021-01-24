    static void Main()
    {
	    var setA = new[]
    	{
	    	new DateTime(2017, 8, 20),
    		new DateTime(2017, 8, 21),
    		new DateTime(2017, 8, 22),		
    		new DateTime(2017, 8, 23),		
    		new DateTime(2017, 8, 24),
    	};
    	var setB = new[]
    	{
    		new DateTime(2017, 8, 20),
    		new DateTime(2017, 8, 21),
    		new DateTime(2017, 8, 22),
    	};
    	var setC = new[]
    	{
	    	new DateTime(2017, 8, 22),
		    new DateTime(2017, 8, 23),
    		new DateTime(2017, 8, 24),
	    	new DateTime(2017, 8, 25),
		    new DateTime(2017, 8, 26),
    	};
	    var setD = new[]
    	{
	    	new DateTime(2017, 8, 20),
		    new DateTime(2017, 8, 21),
    		new DateTime(2017, 8, 22),
	    	new DateTime(2017, 8, 23),
    	};
	    var compareList = new List<DateTime[]>
    	{
	    	setA, setB, setC, setD
    	};
        // setting the threshold to 2 will cause 8/24 to be added to the result...
        // setting this to 1 (default) will return all intersections
        // for now, set it to 3, per the question!
    	var result = CompareDates(compareList, 3); 
	    foreach (var intersectDate in result)
    	{
    		Console.WriteLine(intersectDate);
    	}
    }
