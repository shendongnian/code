    string input = "1.2 3.4 5.6 7.8 9";
		
    List<string> beforeDot = new List<string>();
    List<string> afterDot = new List<string>();
		
    foreach(string s in input.Split())
    {
	    var split = s.Split('.');
			
		if(split.Length == 2)
		{
			beforeDot.Add(split[0]);
			afterDot.Add(split[1]);
		}
	}
    string beforeDots = string.Join(", ", beforeDot);
    string afterDots = string.Join(", ", afterDot);
