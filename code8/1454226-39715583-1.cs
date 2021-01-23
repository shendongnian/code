	public class Question
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Action { get; set; }
		public string Topic { get; set; }
		public string Body { get; set; }
		public string Time { get; set; }
		public string _99 { get; set; }
	
		private static Dictionary<string, Action<Question, string>> __assignments = new Dictionary<string, Action<Question, string>>()
		{
			{ "0", (q, t) => q.Id = t },
			{ "1", (q, t) => q.Name = t },
			// ...
			{ "99",  (q, t) => q._99 = t },
		};
	
		public void SetProperty(string key, string value)
		{
			__assignments[key](this, value);
		}
	}
	
	public void Process(string data)
	{
		Question question = new Question();
		string[] fields = data.Split(':');
	
		for (int i = 0; i < fields.Length; i += 2)
		{
			question.SetProperty(fields[i], fields[i + 1]);
		}
	}
