    using Newtonsoft.Json;
    class Program
    {
    	static void Main(string[] args)
    	{
    		string json = File.ReadAllText(args[0]);
    
    		Message sdata = new Message();
    
    		sdata = JsonConvert.DeserializeObject<Message>(json);
    
    		Console.ReadKey();
    	}
    }
    
    [Serializable]
    public class Test
    {
    	public int a;
    	public float b;
    	public string c;
    	public int [] d;
    	public Dictionary<string,int> e;
    }
    
    [Serializable]
    public class Message
    {
    	public String text;
    	public Test[] data;
    }
