    void Main()
    {
    	var json = "{ \"name\": \"Dylan\"}";
    	var x = Deserialize(json, new { name = null as string});
    	Console.WriteLine(x.name);
    }
    
    T Deserialize<T>(string json, T template)
    {
    	return (T) JsonConvert.DeserializeObject(json, typeof(T));
    }
