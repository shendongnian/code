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
           using (StreamReader r = new StreamReader("C:\\temp\\crms.json"))
			{
				string json = r.ReadToEnd();
				List<Sample> principalArray = JsonConvert.DeserializeObject<List<Sample>>(json);
				foreach (var principalItem in principalArray)
				{
					Console.WriteLine("{0} {1}", principalItem.RecordProcessID, principalItem.CallProcessID);
					foreach (var field in principalItem.FieldList)
					{
						Console.WriteLine("{0} {1}", field.fieldName, field.fieldValue);
					}
				}
				Console.ReadLine();
			}
        }
