		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			Entity entity = new Entity();
			entity.CausedBy = new List<Entity>();
			entity.CausedBy.Add(new Subclass1());
			entity.CausedBy.Add(new Subclass2());
			entity.CausedBy.Add(new Subclass2());
			entity.CausedBy.Add(new Subclass1());
			entity.CausedBy.Add(new Subclass1());
			entity.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Test.txt"));
		}
	}
	[Serializable]
	[XmlRoot("Entity")]
	public class Entity
	{
		[XmlArray("CausedBy")]
		[XmlArrayItem("SubClass1", typeof(Subclass1))]
		[XmlArrayItem("SubClass2", typeof(Subclass2))]
		public List<Entity> CausedBy { get; set; }
	}
	[Serializable]
	[XmlRoot("Subclass1")]
	public class Subclass1 : Entity
	{
		[XmlIgnore]
		String t = DateTime.Now.ToShortDateString();
		public String SubClass1Item { get { return "Test1 " + t; } set { } }
	}
	[Serializable]
	[XmlRoot("Subclass2")]
	public class Subclass2 : Entity
	{
		[XmlIgnore]
		String t = DateTime.Now.ToString();
		public String SubClass2Item { get { return "Test2 " + t; } set { } }
	}
