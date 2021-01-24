    //Example class
    public class Root
    {
    	public Dictionary<string, JRaw> properties { get; set; }
    }
    var json = "<from the question>";
    var result = JsonConvert.DeserializeObject<Root>(json);
	foreach (var property in result.Properties)
	{
		var value = property.Value.ToString();
	}
