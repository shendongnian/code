    void Main()
    {
    	var parameterType = Expression.Parameter(typeof(Info), "obj");
    	
    	var memmberExpressionProperty = Expression.Property(parameterType, "Email");
    
    	
	    HashSet<string> emailPatterns = new HashSet<string>
	    {	 
	      @"^(.*@gmail\.com|bob@.*\.com|tony.?.?@.*\.com)$"
	    };
    
    	MethodInfo filtersMethodInfo = typeof(StringExtensions).GetMethod("RegexMatch", new[] { typeof(string), typeof(HashSet<string>) });
    
    	ConstantExpression	filtersConstantExpression = Expression.Constant(emailPatterns, typeof(HashSet<string>));
    
    	var finalExpression = Expression.Call(null, filtersMethodInfo, memmberExpressionProperty, filtersConstantExpression);
    	
    	var resultFunc = Expression.Lambda<Func<Info, bool>>(finalExpression, parameterType).Compile();
    	
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
