    static public class ExtensionMethods
	{
		static public bool ContainsAny(this string input, IEnumerable<string> searchFor) 
		{
			return searchFor.Any( s => input.Contains(s) );
		}
		static public bool ContainsAny(this string input, params string[] searchFor) 
		{
			return searchFor.Any( s => input.Contains(s) );
		}
	}
