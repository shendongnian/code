    public class Program
    {
    	public static void Main()
    	{
    		Foo foo = new Foo { Bar = "\u001d" };
    		string json = Newtonsoft.Json.JsonConvert.SerializeObject(foo);
    		Console.WriteLine(json);
    		DumpCharsAsHex(json);
    		
    		string json2 = RestSharp.SimpleJson.SerializeObject(foo);
    		Console.WriteLine(json2);
    		DumpCharsAsHex(json2);
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
    
    public class Foo
    {
    	public string Bar { get; set; }	
    }
