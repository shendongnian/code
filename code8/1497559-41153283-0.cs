    void Main()
    {
    	"Hello World!".it().Dump();
    }
    public static class StringExtensions
    {
    	public static IEnumerable<char[]> it(this string s)
    	{
    		if (string.IsNullOrEmpty(s))
    			yield break;
    		
    		var z = CharacterClass(s[0]);
    		var chars = new List<char>();
    		foreach(var c in s)
    		{
    			var c2=CharacterClass(c);
    			if (c2!=z)
    			{
    				yield return chars.ToArray();
    				chars.Clear();
    				z=c2;
    			}
    			chars.Add(c);
    		}
    		yield return chars.ToArray();
    	}
    	
    	public static int CharacterClass(char c)
    	{
            // 1 = vowel
            // 2 = space characters
            // 3 = punctuation
            // 0 = everything else
    		var classes = new Dictionary<char,int> {{'a',1},{'e',1},{'i',1},{'o',1},{'u',1},{' ',2},{'!',3}};
    		if (classes.Keys.Contains(c))
    		{
    			return classes[c];
    		}
    		return 0;
    	}
    }
