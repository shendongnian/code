    public class SampleListItem
		{
			public string fieldName { set; get; }
			public string fieldValue { set; get; }
		}
		public class Sample 
		{ 
			public int RecordProcessID { set; get; }
			public int CallProcessID {set; get; }
			public List<SampleListItem> FieldList { set; get; }
		}
        public ActionResult Index()
        {
           using (StreamReader r = new StreamReader("c:\\temp\\crms.json"))
			{
				string json = r.ReadToEnd();
				List<Sample> array = JsonConvert.DeserializeObject<List<Sample>>(json);
				foreach (var item in array)
				{
					Console.WriteLine("{0} {1}", item.RecordProcessID, item.CallProcessID);
				}
				Console.ReadLine();
			}
        }
