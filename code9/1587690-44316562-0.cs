	public class Detail
	{
		public string first { get; set; }
		public string last { get; set; }
	}
	
	public class Main
	{
		public string date1 { get; set; }
		public string summary { get; set; }
		public List<Detail> Details { get; set; }
	}
	
	public class Attachment
	{
		public string title { get; set; }
		public string file_name { get; set; }
		public string file_content_type { get; set; }
		public string file_format { get; set; }
		public byte [] file_data { get; set; }
	}
	
	public class PostData
	{
		public Main Main { get; set; }
		public List<Attachment> attachments { get; set; }
	}
