    /// <summary>
    /// Tyoe text into field
    /// </summary>
    /// <param name="input">Field</param>
    /// <param name="text">Text to tyoe</param>
    /// <param name="speed">Speed of typing (chars per minute). 0 means default selenium speed</param>
    public static void Type(this IWebElement input, string text, int speed = 0)
    {
    	if (speed == 0)
    	{
    		input.SendKeys(text);
    	}
    	else
    	{
    		var delay = (1000*60)/speed;
    		foreach (var charToType in text)
    		{
    			input.SendKeys(charToType.ToString());
    			Thread.Sleep(delay);
    		}
    	}
    }
