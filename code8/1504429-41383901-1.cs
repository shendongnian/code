	List<TextItemRecord> test;
	public Form1()
	{
		InitializeComponent();
		test = new List<TextItemRecord>()
		{
			new TextItemRecord(1234, "AAA"),
			new TextItemRecord(5678, "BBB"),
			new TextItemRecord(9012, "CCC")
		};
		listBox1.DataSource = test;
	}
