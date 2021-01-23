	public class Item
	{
		public string Id { get; set; }
		public string UserId { get; set; }
		public DateTime DateTime { get; set; }
	}
	public class Book:Item
	{
		public string Name { get; set; }
		public override string ToString()
		{
			return $"Book:    Id: {Id.PadRight(7)} - Name: {Name.PadRight(14)} - DateTime: {DateTime}";
		}
	}
	public class Comment:Item
	{
		public string BookId { get; set; }
		public string Content { get; set; }
		public override string ToString()
		{
			return $"Comment: Id: {Id.PadRight(7)} - Content: {Content.PadRight(11)} - DateTime: {DateTime}";
		}
	}
