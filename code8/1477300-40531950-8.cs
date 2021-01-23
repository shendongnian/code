    public class Program
    {
    	public static void Main()
    	{
    		DumpCharsAsHex("\u001d");   // inserts actual 0x001d character (Group Separator) into string
    		DumpCharsAsHex("\\u001d");  // inserts chars '\', 'u', '0', '0', '1', 'd' into string
    	}
    	
    	private static void DumpCharsAsHex(string s)
    	{
    		if (s != null)
    		{
    			for (int i = 0; i < s.Length; i++)
    			{
    				int c = s[i];
    				Console.Write(c.ToString("X") + " ");
    			}
    		}
  			Console.WriteLine();
    	}
    }
