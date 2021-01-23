	public partial class TestForm : Form {
	
		public TestForm()
		{
			InitializeComponent();
			Load += new EventHandler(TestForm_Load); // !!  Add this line  !!
		}
		
		private void TestForm_Load(object sender, EventArgs e)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			if (!Directory.Exists(path + "\\TestFolder"))
				Directory.CreateDirectory(path + "\\TestFolder");
			if (!File.Exists(path + "\\TestFolder\\settings.xml"))
				File.Create(path + "\\TestFolder\\settings.xml");
		}
	}
