    public sealed class component
    {
    	public section section { get; set; }
    }
    public sealed class section
    {
    	public string title { get; set; }
    	public text text { get; set; }
    }
    public sealed class text
    {
    	public content content { get; set; }
    }
    public sealed class content
    {
    	public string text { get; set; }
    	public string ID { get; set; }
    }
