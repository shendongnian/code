    public struct ListboxData
    {
        public string Category;
        public string Displayname;
        public string ID;
        public List<string> IDTags;
        public string FaultTxt;
        public string Suggestion;
        public string Comments;
        public List<string> MoreQuestions;
    }
	public class Test
	{
        public List<ListboxData> Categories = new List<ListboxData>();
		public Test()
		{            
			Categories.Add(new ListboxData
			{
			    Category = "CATEGORY",
			    Displayname = "COOLING",
			    ID = "CAT_COOL",
			    IDTags = new List<String>{ ""},
			    FaultTxt = "",
			    Suggestion = "",
			    Comments = "",
			    MoreQuestions = new List<String>{ ""}
			});
		}
	}
    public class Program
    {
        public static void Main(string[] args)
        {
            var test = new Test(); 
            Console.WriteLine(test.Categories.First().Displayname);
        }
    }
