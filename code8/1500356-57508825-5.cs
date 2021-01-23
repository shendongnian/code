	public class PersonFilterParams : IFilterParams<Person>
	{
		[Filter( FilterType.Equals )]
		public string Name { get; set; }
		[Filter( nameof( Person.Age ), FilterType.GreaterOrEquals )]
		public int? MinAge { get; set; }
		[Filter( nameof( Person.Age ), FilterType.LessOrEquals )]
		public int? MaxAge { get; set; }
		[Filter( nameof( NonExistingProp ), FilterType.LessOrEquals )]
		public int? NonExistingProp { get; set; }
	}
