    public static class StringExtensions
    {
    	private static char[] _alphabet;
    
    	static StringExtensions()
    	{
    		_alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    	}
    
    	public static bool ContainsAlphabet(this string input)
    	{
    		return !_alphabet
    			.Except(new HashSet<char>(input))
    			.Any();
    	}
    }
	"asdasd".ContainsAlphabet(); //false
    "abcdeffffghijklmnopqrstuvwxyzzz".ContainsAlphabet(); //true
