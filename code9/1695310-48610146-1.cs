    	public class Answers
	{
		public string correct { get; set; }
		public List<string> wrong { get; set; }
	}
	public class Question
	{
		public string title { get; set; }
		public Answers answers { get; set; }
	}
	public class RootObject
	{
		public List<Question> question { get; set; }
	}
---
    var model = JsonConvert.DeserializeObject<RootObject>(jsonstring);
