	public class Foo : IEntity
	{
		public string X1 { get; set; }
		public string X2 { get; set; }
		public string X3 { get; set; }
	
	}
	
	public class Bar : IMarker
	{
		public string SomeProp { get; set; }
		public string Y { get; set; }
	}
	
	public interface IEntity
	{
	}
	
	public interface IMarker : IEntity
	{
		string SomeProp { get; set; }
	}
