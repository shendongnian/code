	public class Rootobject
	{
		[JsonProperty(PropertyName = "output-parameters")]
		public List<OutputParameters> outputparameters { get; set; }
	}
	public class OutputParameters
	{
		[JsonProperty(PropertyName = "value")]
		public SomeValue value { get; set; }
		
		[JsonProperty(PropertyName = "type")]
		public string type { get; set; }
		
		[JsonProperty(PropertyName = "name")]
		public string name { get; set; }
		
		[JsonProperty(PropertyName = "scope")]
		public string scope { get; set; }
	}
	public class SomeValue
	{
		[JsonProperty(PropertyName = "array")]
		public SomeArray array { get; set; }
		
		[JsonProperty(PropertyName = "array")]
		public SomeString1 _string { get; set; }
	}
	public class SomeArray
	{
		[JsonProperty(PropertyName = "elements")]
		public List<SomeElement> elements { get; set; }
	}
	public class SomeElement
	{
		public SomeString _string { get; set; }
	}
	public class SomeString
	{
		[JsonProperty(PropertyName = "value")]
		public string value { get; set; }
	}
	public class SomeString1
	{
		[JsonProperty(PropertyName = "value")]
		public string value { get; set; }
	}
	
