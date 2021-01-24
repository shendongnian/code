    public static ConsoleColor SetColor(RanngDe R)
    {
    	switch (R)
    	{
    		case RanngDe.Blue:
    			return Console.BackgroundColor = ConsoleColor.Blue;
    	    default: return ConsoleColor.Black;
    	}
    }
