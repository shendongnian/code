	public void ColorInfo(string colorName)
	{
		Colors tryParseResult;
		if (Enum.TryParse<Colors>(colorName, out tryParseResult))
		{
            // the string value could be parsed into a valid Colors value
			switch (tryParseResult)
		    {
		        // i need a checking like (colorname=="red")
		        case Colors.red:
		            Console.log("red color");
		            break;
		    }
		}
		else
		{
			// the string value you got is not a valid enum value
			// handle as needed
		}
	}
