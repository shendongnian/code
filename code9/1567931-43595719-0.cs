	public class ARealmClass : RealmObject
	{
		public int Key { get; set; }
		public string KeyString { get; set; }
	}
	public class ARealmClassFilter : RealmObject
	{
		[PrimaryKey]
		public int Key { get; set; }
		public int FilterKeyBy { get; set; }
	}
