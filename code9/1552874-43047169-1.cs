    void Main()
    {
        // Create EXpression parameter for the Info Type
    	var parameterType = Expression.Parameter(typeof(Info), "obj");
    	
        // Access the Email member for the Type Info in the Expression type
    	var memmberExpressionProperty = Expression.Property(parameterType, "Email");
    
    	// Regex Patterns
	    HashSet<string> emailPatterns = new HashSet<string>
	    {	 
	      @"^(.*@gmail\.com|bob@.*\.com|tony.?.?@.*\.com)$"
	    };
    
        // Wrapping and Calling the Extension method for Regex match
    	MethodInfo filtersMethodInfo = typeof(StringExtensions).GetMethod("RegexMatch", new[] { typeof(string), typeof(HashSet<string>) });
    
        // Create Constant Expression and supply the Email Patterns Hashset
    	ConstantExpression	filtersConstantExpression = Expression.Constant(emailPatterns, typeof(HashSet<string>));
    
        // Create Final Expression - MethodCall Expression
    	var finalExpression = Expression.Call(null, filtersMethodInfo, memmberExpressionProperty, filtersConstantExpression);
    	
        // Compile the EXpression Lambda
    	var resultFunc = Expression.Lambda<Func<Info, bool>>(finalExpression, parameterType).Compile();
    	
        // Email Data for filtering
    	List<Info> EmailInfo = new List<Info>()
	   {
	     new Info {Email="abcd@gmail.com"},
	     new Info {Email="abcc@gmail2.com"},
	     new Info {Email="vbhg@guuumail.com"},
	     new Info {Email="kkkk@gmail.com"},
	     new Info {Email="jjjj@gqqqmail.com"}
    };
    
    	var finalResult = EmailInfo.Where(obj => resultFunc(obj));
    }
    
    public static class StringExtensions
    {
    	public static bool RegexMatch(this string source, HashSet<string> patternHashset)
    	{
    		return source != null && patternHashset.Any(pattern => Regex.Match(source, pattern, RegexOptions.IgnoreCase).Success);
    	}
    }
    
    public class Info
    {
    	public string Email { get; set;}
    }
