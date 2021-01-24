    public static void CombiParentheses(int open, int close, StringBuilder str)
    {
    	Console.WriteLine("open: {0}; close: {1}; str: {2}", open, close, str.ToString());
    	if (open == 0 && close == 0)
    	{
    		Console.WriteLine(str.ToString());
    		str.Clear();
    	}
    
    	if (open > 0)
    	{
    		CombiParentheses(open - 1, close + 1, str.Append("("));
    	}
    	
    	if (close > 0)
    	{
    		CombiParentheses(open, close - 1, str.Append(")"));
    	}
    }
    public static void CombiParenthesesFixed(int open, int close, string str)
    {
    	Console.WriteLine("open: {0}; close: {1}; str: {2}", open, close, str);
    	if (open == 0 && close == 0)
    	{
    		Console.WriteLine(str);
    	}
    
    	if (open > 0)
    	{
    		CombiParentheses(open - 1, close + 1, str + "(");
    	}
    	
    	if (close > 0)
    	{
    		CombiParentheses(open, close - 1, str + ")");
    	}
    }
