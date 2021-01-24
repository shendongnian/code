    void Main()
    {
    	Debug.Print(Homework_Problem_Number_54_000_601.
              Parse("NAME SURNAME NUMBER @2131231313"));
        //this prints "NAME SURNAME NUMBER " without the quotes to the console
    }
    
    void SetTextBoxText(TextBox textBox, string value) { textBox.Text = value; }
    
    unsafe static class Homework_Problem_Number_54_000_601
    {
    	[ThreadStatic]static StringBuilder __builder;
    	
    	public static string Parse(string textToParse)
    	{
    		if (textToParse == null) return null;
    		
    		var builder = __builder = __builder ?? new StringBuilder();
    		builder.clear();
    		fixed (char* pTextToParse = textToParse)
    		{
    			var pTerminus = pTextToParse + textToParse.Length;
    			for (var pChar = pTextToParse; pChar < pTerminus; ++pChar)
    			{
    				switch (*pChar)
    				{
    					case '@':
    						return builder.ToString();
    						break;
    					default:
    						builder.Append(*pChar);
    						break;
    				}
    			}
    		}
    		
    		throw new ArgumentException("textToParse was not in the expected format");
    	}
    }
