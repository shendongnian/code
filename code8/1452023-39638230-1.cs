	public class MergeFieldsReload
	{
		public string FNAME { get; set; }
		public string LNAME { get; set; }
		public string CUSTOMERID { get; set; }
		public string DOB { get; set; }
		public string CLINICCODE { get; set; }
	}
	public class DataReload
	{
		public string email_address { get; set; }
		public string status { get; set; }
		public MergeFieldsReload merge_fields { get; set; } = new MergeFieldsReload();
	}
