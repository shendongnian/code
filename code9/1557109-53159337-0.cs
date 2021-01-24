    public static double mtdGetDouble(string Value)
    {
    	if (Value == "" || Value == "-") return 0;
    	else return Convert.ToDouble(Value);
    }
