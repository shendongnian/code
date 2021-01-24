	public class Paged<T>
	{
		public IEnumerable<T> Items { get; set; }
		public int Page { get; set; }
		public int Size { get; set; }
		public int Total { get; set; }
	}
	
	public class Asset
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
