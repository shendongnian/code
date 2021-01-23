	public class MyType
	{
		public string Col1 { get; set; }
		public string Col2 { get; set; }
	}
	
	List<MyType> list = db.Database.SqlQuery<MyType>("select Col1, Col2 from ....").ToList();
