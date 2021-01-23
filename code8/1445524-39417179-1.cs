    public class A
    {
    	[JsonProperty("custom")]
    	public Dictionary<string, string> Custom
    	{
    		get;
    		set;
    	}
    }
    public class Program
    {
    	public static void Main()
    	{
    		A custom = new A();
    		custom.Custom = new Dictionary<string, string>(){
    			{"destination1", "foo"},
    			{"destination2", "bar"},
    		};
    		Console.WriteLine(JsonConvert.SerializeObject(custom));
    	}
    }
