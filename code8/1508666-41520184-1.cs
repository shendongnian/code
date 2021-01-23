	public class person : RealmObject
	{
		public string firstname { get; set; }
		public string secondname { get; set; }
		public int age { get; set; }
		public string address { get; set; }
		public string name { get { return firstname + " " + secondname; } }
	}
