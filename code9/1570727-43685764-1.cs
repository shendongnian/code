    public class Environment
    {
    	Dictionary<string, string> KeyValueData { get; set; }
    	public string Name { get; set; }
    	public Environment(string name)
    	{
    		Name = name;
    		KeyValueData = new Dictionary<string, string>();
    	}
    
    	public void AddNewData(string key, string value)
    	{
    		this.KeyValueData.Add(key, value);
    	}
    }
