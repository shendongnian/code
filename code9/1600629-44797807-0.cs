	public bool IsValid(string input = "")
	{
		double inputParsed;
		if (!double.TryParse(input, out inputParsed))
		    return false;
		if(inputParsed < 0 || inputParsed > 20479)
		    return false;
		return true;
	}
