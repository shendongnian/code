	// Entity class
	public partial class FooEntity
	{
		public string Name { get; set;} 
	}
	// User-created partial class
	public partial class FooEntity
	{
		[Required]
		public string Name { get; set;} 
	}
