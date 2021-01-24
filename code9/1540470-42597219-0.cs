	public class ARealmObject : RealmObject
	{
		[PrimaryKey] // Use Gap-less Primary keys for super fast RecyclerView, otherwise you have to create a "positional" RealmObject mapping
		public int Key { get; set; } // zero-based for RecyclerView Adapter
		public string Caption { get; set; }
		public int SeekBar1 { get; set; }
		public int SeekBar2 { get; set; }
	}
