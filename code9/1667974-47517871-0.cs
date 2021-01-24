        public List<FacebookPost> data { get; set; }
        public Paging3 paging { get; set; }
		public FacebookPostData()
		{
			this.data = new List<FacebookPost>();
			this.paging = new Paging3();
		}
    }
	
	public class FacebookPost
    {
        public string id { get; set; }
        public string created_time { get; set; }
        public Reactions reactions { get; set; }
        public Comments comments { get; set; }
		public FacebookPost()
		{
			this.reactions = new Reactions();
			this.comments = new Comments();
		}
    }
	
	public class Paging3
    {
        public string previous { get; set; }
        public string next { get; set; }
    }
	
	public class Reactions
    {
        public List<Data2> data { get; set; }
        public Paging paging { get; set; }
		public Reactions()
		{
			this.data = new List<Data2>();
			this.paging = new Paging();
		}
    }
	
	public class Data2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
	
	public class Paging
    {
        public Cursors cursors { get; set; }
		public Paging()
		{
			this.cursors = new Cursors();
		}
    }
    public class Cursors
    {
        public string before { get; set; }
        public string after { get; set; }
    }
    public class Comments
    {
        public List<Data3> data { get; set; }
        public Paging2 paging { get; set; }
		public Comments()
		{
			this.data = new List<Data3>();
			this.paging = new Paging2();
		}
    }
	
	public class Data3
    {
        public string created_time { get; set; }
        public From from { get; set; }
        public string message { get; set; }
        public string id { get; set; }
		public Data3()
		{
			this.from = new From();
		}
    }
	
	public class Paging2
    {
        public Cursors2 cursors { get; set; }
		public Paging2()
		{
			this.cursors = new Cursors2(); 
		}
    }
	
    public class From
    {
        public string name { get; set; }
        public string id { get; set; }
    }
	
    public class Cursors2
    {
        public string before { get; set; }
        public string after { get; set; }
    }
  
