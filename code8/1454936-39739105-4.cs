    public enum Foo { A, B, C }
	public class RootObject
	{
		[JsonConverter(typeof(NoConverter))]
		public Foo FooAsInteger { get; set; }
		
		public Foo FooAsString { get; set; }
	}
