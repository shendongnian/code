    string input = "1.2 3.4 5.6 7.8 9";
		
    List<string> beforeDot = new List<string>();
    List<string> afterDot = new List<string>();
		
    foreach(string s in input.Split())
    {
	    var split = s.Split('.');
			
		beforeDot.Add(split[0]);
			
		if(split.Length == 2)
		{				
			afterDot.Add(split[1]);
		}
	}
    string beforeDots = string.Join(", ", beforeDot);
    string afterDots = string.Join(", ", afterDot);
