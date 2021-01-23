	public class Rootobject
	{
		public string type { get; set; }
		public List[] list { get; set; }
	}
	public class List
	{
		public int objectlistid { get; set; }
		public int objectlisttypeid { get; set; }
		public string objectlistname { get; set; }
		public int clienttaxonomyid { get; set; }
		public string clienttaxonomy { get; set; }
		public int order { get; set; }
		public Contact[] contacts { get; set; }
	}
	public class Contact
	{
		public long personid { get; set; }
		public string fullname { get; set; }
		public int userid { get; set; }
		public string userclientcode { get; set; }
		public Contactdetail[] contactdetails { get; set; }
	}
	public class Contactdetail
	{
		public int contactid { get; set; }
		public int contacttypeid { get; set; }
		public string contactdata { get; set; }
	}
