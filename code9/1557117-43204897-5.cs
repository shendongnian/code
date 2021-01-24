    public static string SetColor(RanngDe R)
    {
    	switch (R)
    	{
    		case RanngDe.Blue:
    			return (Console.BackgroundColor = ConsoleColor.Blue).ToString();
    	}
    }
