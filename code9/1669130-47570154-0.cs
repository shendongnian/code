	public class PersonDto
	{
		[JsonProperty("Name")]
		public string Name { get; set; }
		[JsonProperty("Age")]
		public int Age { get; set; }
		[JsonProperty("EyeColor")]
		public string EyeColor { get; set; }
	}
