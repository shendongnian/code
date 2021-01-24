    public class Option
    {
        public string Code { get; set; }
		[DeserializeAs(Name = "Value")]
        public string Description { get; set; }
    }
		
