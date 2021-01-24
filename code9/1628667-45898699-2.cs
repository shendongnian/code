    using System;
    
    public class Test
    {
    	public static void Main()
    	{
    		string scrapedElement = "test test .html test";
    		string [] Test = scrapedElement.Contains(".html") 
                                ? new string[] { scrapedElement, string.Empty } 
                                : new string[] { scrapedElement };
    	}
    }
