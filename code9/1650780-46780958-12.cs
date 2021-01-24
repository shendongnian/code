    public static List<List<string>> Make2DList(List<string> input, int width=4)  
	{        
		var output = new List<List<string>>(); 
	
		for (int i=0; i < input.Count; i+= width) 
		{ 
			output.Add(input.GetRange(i, Math.Min(width, input.Count - i))); 
		} 
	
		return output; 
	} 
