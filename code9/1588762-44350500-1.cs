    public class Foo
    {
    	[JsonConverter(typeof(TagsConverter), " ")]
    	public List<string> Tags { get; set; }
    }
