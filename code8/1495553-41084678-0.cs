	public Tuple<string, int> GetValues()
	{
		// ...
		return new Tuple(stringVal, intVal);
	}
	
	var value = GetValues();
	string s = value.Item1;	
