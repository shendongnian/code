    public class RootObject {
    	[JsonProperty("questions")]
    	public List<Question> Questions {get;set;}
    	[JsonProperty("title")]
        public string Title { get; set; }
    	[JsonProperty("description")]
        public string Description { get; set; }
    }
    public class Question
    {
    	[JsonProperty("check")]
        public List<string> Check { get; set; }
    }
