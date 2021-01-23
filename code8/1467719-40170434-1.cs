    public class Test
    {
    	public static void Main()
    	{
    		string input = @"aaa bbbb; Name=John Lewis; ccc ddd; Age=20;";
        	string pattern = @"Name=(?<Name>.+?);.+Age=(?<Age>.+?);";
        
    	    var match = Regex.Match(input, pattern);
    	    if (match.Success)
    	    {
    	        string name = match.Groups["Name"].Value;
    	        string age = match.Groups["Age"].Value;
    	
    	        Console.WriteLine("Name: " + name);
    	        Console.WriteLine(" Age: " + age);
    	    }
    	}
    }
