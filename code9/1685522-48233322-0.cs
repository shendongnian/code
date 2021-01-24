    void Main()
    {
	    foreach(var w in createMatchables("real"))
	    {
		    Console.WriteLine(w);
	    }
    }
    // this creates all the searchable substrings from a given string
    // all the strings are created from left to right
    List<string> createMatchables(string str)
    {
	    var matchList = new List<string>();
	
	    for (int i = str.Length; i != 0; i--)
	    {
		    var branchCount = str.Length / i;
		
		    for (int j = 0; j < branchCount; j++)
		    {
			    matchList.Add(str.Substring(i*j, i));
		    }
	    }
	
	    return matchList;
    }
