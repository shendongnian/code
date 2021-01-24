	public class JobDataWithDeadlines
	{
		public int? jobNum {get;set;}
		public string jobName {get;set;}
		/* snip */
		public List<StatusData> StatusDatas {get;set;}
	}
	public class StatusData
	{
		public int scId {get;set;}
		public int JobNum {get;set;}
		public string StatusComment {get;set;}
		public string scTimeStamp {get;set;}
		public bool IsNew {get;set;}
	}
