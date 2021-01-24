        private readonly string _category;
        private readonly string _displayname;
        private readonly string _id;
        private readonly List<string> _idTags;
        private readonly string _faultTxt;
        private readonly string _suggestion;
        private readonly string _comments;
        private readonly List<string> _moreQuestions;
        
        public ListboxData(string category, string displayname, string id, List<string> idTags, string faultTxt, string suggestion, string comments, List<string> moreQuestions)
        {
            _category = category;
            _displayname = displayname;
            _id = id;
            _idTags = idTags;
            _faultTxt = faultTxt;
            _suggestion = suggestion;
            _comments = comments;
            _moreQuestions = moreQuestions;
        }
        public string Category
        {
            get { return _category; }
        }
        public string Displayname
        {
            get { return _displayname; }
        }
        public string Id
        {
            get { return _id; }
        }
        public List<string> IdTags
        {
            get { return _idTags; }
        }
        public string FaultTxt
        {
            get { return _faultTxt; }
        }
        public string Suggestion
        {
            get { return _suggestion; }
        }
        public string Comments
        {
            get { return _comments; }
        }
        public List<string> MoreQuestions
        {
            get { return _moreQuestions; }
        }
    }
	public class Test
	{
        public List<ListboxData> Categories = new List<ListboxData>();
		public CoolingListTest()
		{            
			Categories.Add(new ListboxData(
                category: "CATEGORY",
                displayname: "COOLING",
                id: "CAT_COOL",
                idTags: new List<String> { "" },
                faultTxt: "",
                suggestion: "",
                comments: "",
                moreQuestions: new List<String> { "" }
             ));
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
