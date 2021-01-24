    //Come up a better name...
	public static List<int> ConvertToIntListNoLinq(string input)
	{
		List<int> output = new List<int>();
		foreach(string s in input.Split(','))
		{
			if(int.TryParse(s, out int result))
			{
				output.Add(result);
			}				
		}
		return output;
	}
