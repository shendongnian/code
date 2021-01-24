    public double GetDouble(Object input)
    {
		if (input is DoubleContainer)
		{
        	var dc = (DoubleContainer)input; 
            return (double)dc;
		}
        return (double)input;
    }
